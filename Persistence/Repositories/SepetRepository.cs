using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;
using robotistan.Domain.Repositories;
using robotistan.Persistence.Contexts;

namespace robotistan.Persistence.Repositories
{
	public class SepetRepository : BaseRepository, ISepetRepository
	{
		public SepetRepository(AppDbContext context) : base(context) { }


		public Task AddAsync(Sepet sepet)
		{
			throw new System.NotImplementedException();
		}

		public Task<Sepet> FindByIdAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<QueryResult<Sepet>> ListAsync(SepetQuery query)
		{
			throw new System.NotImplementedException();
		}

		public void Remove(Sepet sepet)
		{
			throw new System.NotImplementedException();
		}

		public void Update(Sepet sepet)
		{
			throw new System.NotImplementedException();
		}
	}
}
