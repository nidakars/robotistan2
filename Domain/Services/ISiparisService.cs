using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;
using robotistan.Domain.Services.Communication;

namespace robotistan.Domain.Services
{
    public interface ISiparisService
    {
        Task<QueryResult<Siparis>> ListAsync(SiparisQuery query);
        Task<SiparisResponse> SaveAsync(Siparis siparis);
        Task<SiparisResponse> UpdateAsync(int id, Siparis siparis);
        Task<SiparisResponse> DeleteAsync(int id);
    }
}