using System.Collections.Generic;
using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Services.Communication;

namespace robotistan.Domain.Services
{
    public interface ISliderService
    {
        Task<IEnumerable<Slider>> ListAsync();
        Task<SliderResponse> SaveAsync(Slider slider);
        Task<SliderResponse> UpdateAsync(int id, Slider slider);
        Task<SliderResponse> DeleteAsync(int id);

    }
}