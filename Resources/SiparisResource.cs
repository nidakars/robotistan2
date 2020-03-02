using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace robotistan.Resources
{
    public class SiparisResource
    {
        public int Id { get; set; }


        public decimal UrunFiyati { get; set; }
        public decimal SepetToplamTutar { get; set; }
        public string SiparisNo { get; set; }
        public string SepetUser { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public UserResource Category { get; set; }
    }
}
