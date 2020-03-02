using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;
using robotistan.Domain.Services.Communication;

namespace robotistan.Domain.Services
{
    public interface IProductService
    {
        Task<QueryResult<Product>> ListAsync(ProductsQuery query);
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}