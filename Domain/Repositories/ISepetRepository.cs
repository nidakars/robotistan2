using System.Collections.Generic;
using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;

namespace robotistan.Domain.Repositories
{
    interface ISepetRepository
    {
        Task<QueryResult<Sepet>> ListAsync(SepetQuery query);
        Task AddAsync(Sepet sepet);
        Task<Sepet> FindByIdAsync(int id);
        void Update(Sepet sepet);
        void Remove(Sepet sepet);
    }
}
