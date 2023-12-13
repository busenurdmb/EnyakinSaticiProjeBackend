using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.Core.Utilities.Results
{
    //BURDA :Result diiynce sen bir resultsın ve resultın içindeki yapıyı içeriyorsun demek istiyor o adamın constructer var implemente et ozaman
    public class DataResult<T> :Result, IDataResult<T>
    {
        public DataResult(T data,bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data {get; }

        
    }
}
