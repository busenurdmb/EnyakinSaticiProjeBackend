using EnYakınSatıcı.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.Core.Utilities.Business
{
    public  class BusinessRules
    {
        //params yazdığımız zaman istediğimiz kadar parametre ekleyebiliyoruz
        //logic iş kuralı
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    //parametre ile gönderdiğimiz iş kurallarından başarısız olanı
                    //businesa gönderiryoruz
                    return logic;
                }
            }

            return null;
        }
    }
}
