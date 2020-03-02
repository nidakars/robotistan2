namespace robotistan.Domain.Models.Queries
{
    public class SiparisQuery : Query
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }

        public SiparisQuery(int? userId, int? productId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            UserId = userId;
            ProductId = productId;
        }
}
}
