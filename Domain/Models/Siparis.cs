using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace robotistan.Domain.Models
{
    public class Siparis
    {
        public int Id { get; set; }
        
        
        public double UrunFiyati { get; set; }
        public double SepetToplamTutar { get; set; }
        public int SiparisNo { get; set; }
        public string SepetUser { get; set; }
        public DateTime SiparisTarihi { get; set; }



        public int UserId { get; set; }
        public User Users { get; set; }
        public int ProductId { get; set; }
        public  List<Product> Products { get; set; }
    }
}
