using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using En_YakýnSatýcý.DataAccesLayer.Concrete.EntityFramework;
using EnYakýnSatýcý.BusinessLayer.DependencyReselvors.AutoFac;
using EnYakýnSatýcý.Core.Utilities.IoC;
using EnYakýnSatýcý.Core.Utilities.Security.Encryption;
using EnYakýnSatýcý.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EnYakýnSatýcý.Core.Extensions;
using EnYakýnSatýcý.Core.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);
//arkadaþým senin .net core yapýnda biliyorum ýoc yapýsý var onu kullanma fabrika olarak autofac i kullan

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>( builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddControllers();
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("EnYakýnSatýcýCors", opt =>
    {
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddDbContext<EnYakýnSatýcýContext>();
// Add services to the container.


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
      
    }) ;

builder.Services.AddDependencyResolvers(new ICoreModule[] {
               new CoreModule()
 });


//builder.Services.AddSingleton<IProductService,ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //singleton bana arka planda bir referans oluþtur
        //kýsacasý ýoc leer sizin yerinize newliyor
        //biri senden ýproductservice isterse ona arka tarafta productmanager oluþtur diyorsuun.


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("EnYakýnSatýcýCors");

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    
