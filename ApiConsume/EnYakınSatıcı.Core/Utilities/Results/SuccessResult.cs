using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.Core.Utilities.Results;

public class SuccessResult:Result
{
    /// <summary>
    /// succes result sadece mesaj alsın
    /// </summary>base-> Result
    /// true,message diyorum çünkü doğru o yüzden true
    /// <param name="message"></param>
    public SuccessResult(string message) : base(true, message){}
    
    //true default vermiş olduk//
    public SuccessResult() : base(true) { }
}
