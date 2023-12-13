using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using En_YakınSatıcı.DataAccesLayer.Abstract;
using En_YakınSatıcı.DataAccesLayer.Concrete.EntityFramework;
using EnYakınSatıcı.BusinessLayer.Abstract;
using EnYakınSatıcı.BusinessLayer.Concrete;
using EnYakınSatıcı.Core.Utilities.Interceptors;
using EnYakınSatıcı.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.BusinessLayer.DependencyReselvors.AutoFac
{
    public class AutofacBusinessModule:Module
    {
        //load yükleme demek
        //uygulama ayağa kalktığı zaman çalışıcak
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<HttpContextAccessor>().As<HttpContextAccessor>().SingleInstance();
          

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
