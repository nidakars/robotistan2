using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace robotistan.Resources
{
    public class SepetResource
    {
        public int Id { get; set; }
        public string SepetKullanici { get; set; }

        public ProductResource Product { get; set; }
    }
}
