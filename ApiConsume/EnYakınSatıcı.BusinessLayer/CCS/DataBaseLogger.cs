namespace EnYakınSatıcı.BusinessLayer.CCS
{
    public class DataBaseLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("veritabanına loglandı");
        }

    }
}
