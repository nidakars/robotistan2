using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;
using robotistan.Domain.Repositories;
using robotistan.Persistence.Contexts;

namespace robotistan.Persistence.Repositories
{
	public class SliderRepository : BaseRepository, ISliderRepository
	{
		public SliderRepository(AppDbContext context) : base(context) { }

		public Task AddAsync(Slider slider)
		{
			throw new System.NotImplementedException();
		}

		public Task<Slider> FindByIdAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<QueryResult<Slider>> ListAsync()
		{
			throw new System.NotImplementedException();
		}

		public void Remove(Slider slider)
		{
			throw new System.NotImplementedException();
		}

		public void Update(Slider slider)
		{
			throw new System.NotImplementedException();
		}
	}
}
