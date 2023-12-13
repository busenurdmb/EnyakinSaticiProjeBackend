using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using En_Yak�nSat�c�.DataAccesLayer.Concrete.EntityFramework;
using EnYak�nSat�c�.BusinessLayer.DependencyReselvors.AutoFac;
using EnYak�nSat�c�.Core.Utilities.IoC;
using EnYak�nSat�c�.Core.Utilities.Security.Encryption;
using EnYak�nSat�c�.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EnYak�nSat�c�.Core.Extensions;
using EnYak�nSat�c�.Core.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);
//arkada��m senin .net core yap�nda biliyorum �oc yap�s� var onu kullanma fabrika olarak autofac i kullan

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>( builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddControllers();
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("EnYak�nSat�c�Cors", opt =>
    {
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddDbContext<EnYak�nSat�c�Context>();
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

        //singleton bana arka planda bir referans olu�tur
        //k�sacas� �oc leer sizin yerinize newliyor
        //biri senden �productservice isterse ona arka tarafta productmanager olu�tur diyorsuun.


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("EnYak�nSat�c�Cors");

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    
