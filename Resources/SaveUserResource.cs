using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace robotistan.Resources
{
    public class SaveUserResource
    {
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Soyadi { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Sifre { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public DateTime EklenmeTarihi { get; set; }
    }
}
