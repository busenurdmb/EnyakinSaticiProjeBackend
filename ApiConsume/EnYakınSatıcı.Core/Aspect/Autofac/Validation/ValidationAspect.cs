using Castle.DynamicProxy;
using EnYakınSatıcı.Core.CrossCuttingConcerns.Validation;
using EnYakınSatıcı.Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.Core.Aspect.Autofac.Validation
{
    //onuun bir Interception olduğunu anlatmak için onu ondan inherit ediyorsun
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;

        //bana validator type ı ver diyor
        //ATTRIBÜTE TPE ZORUNDAYIZ
        public ValidationAspect(Type validatorType)
        {
            //GÖNDERİLEN validatortype bir validator değilse kız ona
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection
            //productvalidatorun bir instancenı oluştur.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //sonra productvalidatorın çalışma tipini bul
                                  //basetype    genericveritipi
            //ProductValidator :AbstractValidator<Product>
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //onun parametrelerini buldemek ilgili methodun parametreleri
            //invocation method demek 
            //methodun parametreline bak entitytype denk gelnen yanı producta
           // parametreli git bul hepsini her birini tek tek gez
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                //validationtool kulanarak validate et
                ValidationTool.Validate(validator, entity);
            }
        }
    }
    }
