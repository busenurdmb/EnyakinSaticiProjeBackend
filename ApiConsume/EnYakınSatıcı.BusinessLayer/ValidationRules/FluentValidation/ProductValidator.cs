using EnYakınSatıcı.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.BusinessLayer.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //P NİN KATEGORİ IDSİ BİR OLDUĞUNDA FİYATI MİN 10 TL OLMALI
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);
            //OLMAYAN BİR ÖZELLİĞİ VERMEK İSTİYORUM
            //MUST-->UYMALI
            RuleFor(p => p.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");

        }
        //TRU DÖNDÜRÜRSEN KURALA UYGUN FALSE GÖNDERİRİSEN UYGUN DEĞİL
        private bool StartWithA(string arg)
        {
           return arg.StartsWith("A");
        }
    }
}
