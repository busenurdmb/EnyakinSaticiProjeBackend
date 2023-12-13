using Castle.DynamicProxy;



namespace EnYakınSatıcı.Core.Utilities.Interceptors
{
    //claslara ve methodlara ekleyebilirisn bu attiribütü
    //,birden fazla ekleyebilrisin->hem veritabanına loglasın hemde bir dosyay loglasın
    //inherid edilen bir  noktada bu attribute çalışsın diyebilrisin
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //öncelik
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
