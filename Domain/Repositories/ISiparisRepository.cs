using System.Collections.Generic;
using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;

namespace robotistan.Domain.Repositories
{
    interface ISiparisRepository
    {
        Task<QueryResult<Siparis>> ListAsync(SiparisQuery query);
        Task AddAsync(Siparis siparis);
        Task<Siparis> FindByIdAsync(int id);
        void Update(Siparis siparis);
        void Remove(Siparis siparis);
    }
}
}
