using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;
using robotistan.Domain.Services.Communication;

namespace robotistan.Domain.Services
{
    public interface ISepetService
    {
        Task<QueryResult<Sepet>> ListAsync(SepetQuery query);
        Task<SepetResponse> SaveAsync(Sepet sepet);
        Task<SepetResponse> UpdateAsync(int id, Sepet sepet);
        Task<SepetResponse> DeleteAsync(int id);
    }
}