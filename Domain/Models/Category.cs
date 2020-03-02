using System.Collections.Generic;

namespace robotistan.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UstKategoriId { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();
    }
}