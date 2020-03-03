using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;
using robotistan.Domain.Repositories;
using robotistan.Domain.Services;
using robotistan.Domain.Services.Communication;
using robotistan.Infrastructure;

namespace robotistan.Services
{
	public class SiparisService : ISiparisService
	{
		private readonly IUsersRepository _usersRepository;
		private readonly IProductRepository _productRepository;
		private readonly ISiparisRepository _siparisRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMemoryCache _cache;

		public SiparisService(ISiparisRepository siparisRepository, IUsersRepository usersRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
		{
			_siparisRepository = siparisRepository;
			_productRepository = productRepository;
			_usersRepository = usersRepository;
			_unitOfWork = unitOfWork;
			_cache = cache;
		}
		public Task<SiparisResponse> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<QueryResult<Siparis>> ListAsync(SiparisQuery query)
		{
			throw new NotImplementedException();
		}

		public Task<SiparisResponse> SaveAsync(Siparis siparis)
		{
			throw new NotImplementedException();
		}

		public Task<SiparisResponse> UpdateAsync(int id, Siparis siparis)
		{
			throw new NotImplementedException();
		}
	}
}
