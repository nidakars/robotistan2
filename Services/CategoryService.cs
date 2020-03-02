using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using robotistan.Domain.Models;
using robotistan.Domain.Repositories;
using robotistan.Domain.Services;
using robotistan.Domain.Services.Communication;
using robotistan.Infrastructure;

namespace robotistan.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            // Here I try to get the categories list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var categories = await _cache.GetOrCreateAsync(CacheKeys.CategoriesList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _categoryRepository.ListAsync();
            });
            
            return categories;
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"Kategori kaydedilirken hata oluþtu: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Kategori bulunamadý.");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"Kategori güncellenirken hata oluþtu: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Kategori bulunamadý.");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"Kategori silinirken hata oluþtu: {ex.Message}");
            }
        }
    }
}