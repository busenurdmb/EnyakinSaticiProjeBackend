using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnYakınSatıcı.EntityLayer.DTOs
{
    public class UserForRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Şehir { get; set; }
        public string İlçe { get; set; }
        public string Köy { get; set; }
        public string Telefon { get; set; }
    }
}
