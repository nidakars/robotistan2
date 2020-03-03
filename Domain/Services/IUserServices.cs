using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using robotistan.Domain.Models;
using robotistan.Domain.Services.Communication;

namespace robotistan.Domain.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}
