using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace robotistan.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
      
        [DisplayName("Adınız")]
        public string Adi { get; set; }
        [DisplayName("Soyadınız")]
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        [DisplayName("E Mail Adresiniz")]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        public int Sifre { get; set; }
        public long Telefon { get; set; }
        public DateTime EklenmeTarihi { get; set; }


        
        public List<Siparis> Siparisler { get; set; }
    }
}
