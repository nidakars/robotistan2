using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace robotistan.Resources
{
    public class SaveSiparisResource
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal UrunFiyati { get; set; }
        [Required]
        public decimal SepetToplamTutar { get; set; }
        [Required]
        public string SiparisNo { get; set; }
        [Required]
        public string SepetUser { get; set; }
        [Required]
        public DateTime SiparisTarihi { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
