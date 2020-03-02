using System;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<QueryResult<Product>> ListAsync(ProductsQuery query)
        {
            // Here I list the query result from cache if they exist, but now the data can vary according to the category ID, page and amount of
            // items per page. I have to compose a cache to avoid returning wrong data.
            string cacheKey = GetCacheKeyForProductsQuery(query);
            
            var products = await _cache.GetOrCreateAsync(cacheKey, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _productRepository.ListAsync(query);
            });

            return products;
        }

        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                /*
                 Notice here we have to check if the category ID is valid before adding the product, to avoid errors.
                 You can create a method into the CategoryService class to return the category and inject the service here if you prefer, but 
                 it doesn't matter given the API scope.
                */
                var existingCategory = await _categoryRepository.FindByIdAsync(product.CategoryId);
                if (existingCategory == null)
                    return new ProductResponse("Geçersiz kategori.");

                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductResponse($"Ürün kaydedilirken hata oluþtu: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new ProductResponse("Ürün bulunamadý.");

            var existingCategory = await _categoryRepository.FindByIdAsync(product.CategoryId);
            if (existingCategory == null)
                return new ProductResponse("Geçersiz kategori.");

            existingProduct.Name = product.Name;
            existingProduct.QuantityInPackage = product.QuantityInPackage;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Fiyat = product.Fiyat;
            existingProduct.Aciklama = product.Aciklama;
            existingProduct.Marka = product.Marka;
            existingProduct.UrunResmi = product.UrunResmi;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductResponse($"Ürün güncellenirken hata oluþtu: {ex.Message}");
            }
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new ProductResponse("Ürün bulunamadý.");

            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductResponse($"Ürün silinirken hata oluþtu: {ex.Message}");
            }
        }

        private string GetCacheKeyForProductsQuery(ProductsQuery query)
        {
            string key = CacheKeys.ProductsList.ToString();
            
            if (query.CategoryId.HasValue && query.CategoryId > 0)
            {
                key = string.Concat(key, "_", query.CategoryId.Value);
            }

            key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
            return key;
        }
    }
}