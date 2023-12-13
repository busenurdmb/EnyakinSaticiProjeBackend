using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.BusinessLayer.CCS
{
    public class FileLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("dosyaya loglandı");
        }

    }
}
