using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;
using robotistan.Domain.Repositories;
using robotistan.Persistence.Contexts;

namespace robotistan.Persistence.Repositories
{
	public class UserRepository : BaseRepository, IUsersRepository
	{
		public UserRepository(AppDbContext context) : base(context) { }
		public Task AddAsync(User user)
		{
			throw new System.NotImplementedException();
		}

		public Task<User> FindByIdAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<QueryResult<User>> ListAsync()
		{
			throw new System.NotImplementedException();
		}

		public void Remove(User user)
		{
			throw new System.NotImplementedException();
		}

		public void Update(User user)
		{
			throw new System.NotImplementedException();
		}
	}
}
