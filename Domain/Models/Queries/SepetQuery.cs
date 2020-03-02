using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace robotistan.Domain.Models.Queries
{
    public class SepetQuery : Query
    {
        public int? ProductId { get; set; }
        public int? UserId { get; set; }

        public SepetQuery(int? userId, int? productId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            ProductId = productId;
            UserId = userId;
        }
    }
}
    
