﻿using Castle.DynamicProxy;
using EnYakınSatıcı.Core.Utilities.Interceptors;
using EnYakınSatıcı.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.Core.Aspect.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start(); //Metot baslarken kronometreyi calistiriyoruz
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval) //kronometre durana kadar gecen süreyi hesapliyoruz
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}"); //konsola yazdiriyoruz, istenirse mail gönderilebilir ya da log alinabilir
            }
            _stopwatch.Reset();
        }
    }
}
