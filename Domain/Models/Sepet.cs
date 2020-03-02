namespace robotistan.Domain.Models
{
    public class Sepet
    {
        public int Id { get; set; }
        public string SepetKullanici { get; set; }


        public int ProductId { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
    }
}
