using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace robotistan.Resources
{
    public class SaveSepetResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string SepetKullanici { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
