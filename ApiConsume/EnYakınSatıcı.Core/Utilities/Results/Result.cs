

namespace EnYakınSatıcı.Core.Utilities.Results;

public class Result : IResult
{
    public Result(bool success, string message):this(success)
    {
        //hani bu getterdi set edilemezdi
        //Get reodanly dir reodanlyler constructerda set edileblir
        
        Message = message;
       // Success = success;

    }
    
    public Result(bool success) 
    { 
        Success = success;
    }

   

    //YENİ NESİL İMPLEMENTASYON 
    /// <summary>
    /// sadece get olduğu için sadece retun olayı 
    /// getter demek bir şeyi return et demekti
    /// ne yazarsak onu return edicek demektir
    /// interface NotImplemetExceptionla geliyor sen onu implemtee ettin ama doldurmadın anlamına geliyor
    /// </summary>
    public bool Success { get; }
    //setter koysakdık program kafasına göre kodlayabilridi

    public string Message { get; }

   
}
