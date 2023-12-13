using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.Core.Utilities.Results;
/// <summary>
/// temel voidler için başlangıç data yok içinde bir şey döndürmeyecekya void zaten  ekstra bir şey döndürmeyeceği için sadec işlem sonucu ve mesajı döndürmesi yeterli
/// voidleri result yapısıyla süslüyor olucaz
/// içerisinde işlem sonucu ve kullanıcıyı bilgilendirmke için mesaj 
/// yaptığımız şey çok basit apileirmizi ve uygulamayı kullanıcak kiişy doğru yönlerdirmek
/// </summary>
public interface IResult
{
    //nasıl set edicez? consturcter da bu hareketei yapabilrisin 
    bool Success { get; }
    string Message { get; }
}
