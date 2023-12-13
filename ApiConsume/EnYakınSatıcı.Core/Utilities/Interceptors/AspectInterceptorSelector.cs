using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Reflection;

namespace EnYakınSatıcı.Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        //git clasın attrıbütlerini oku
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
            (true).ToList();

        //git methodun attribütlerini oku ve onları bir listeye koy
        var methodAttributes = type.GetMethod(method.Name)
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

        classAttributes.AddRange(methodAttributes);

        //onların çalışma sırasını öncelik değerine göre sırala

      //->  classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));<-
      //otomatik olarak sistemdeki bütün methodları log a dahil et

        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}
