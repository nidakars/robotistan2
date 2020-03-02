using System.Collections.Generic;
using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Services.Communication;

namespace robotistan.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);

    }
}