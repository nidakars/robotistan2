using System.Collections.Generic;
using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;

namespace robotistan.Domain.Repositories
{
    public interface ISliderRepository
    {
        Task<QueryResult<Slider>> ListAsync();
        Task AddAsync(Slider slider);
        Task<Slider> FindByIdAsync(int id);
        void Update(Slider slider);
        void Remove(Slider slider);
    }
}
