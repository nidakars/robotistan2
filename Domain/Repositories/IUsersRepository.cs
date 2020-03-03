using System.Collections.Generic;
using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;


namespace robotistan.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task<QueryResult<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        void Update(User user);
        void Remove(User user);
    }
}
