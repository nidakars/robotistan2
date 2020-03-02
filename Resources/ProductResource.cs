namespace robotistan.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public float Fiyat { get; set; }
        public string Marka { get; set; }
        public string Aciklama { get; set; }
        public string UrunResmi { get; set; }
        public CategoryResource Category {get;set;}
    }
}