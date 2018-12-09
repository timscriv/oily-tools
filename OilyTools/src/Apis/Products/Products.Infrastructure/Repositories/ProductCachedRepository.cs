using Microsoft.Extensions.Caching.Memory;
using Products.Core.Entities;
using Products.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Products.Infrastructure.Repositories
{
    public class ProductCachedRepository : IProductReadOnlyRepository
    {
        private readonly ProductRepository _innerRepository;
        private readonly MemoryCacheEntryOptions cacheOptions;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "Products";

        public ProductCachedRepository(ProductRepository innerRepository, IMemoryCache cache)
        {
            _cache = cache;
            _innerRepository = innerRepository;

            cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
        }

        public IEnumerable<Product> GetAll()
        {
            return _cache.GetOrCreate(CacheKey, cacheEntry =>
            {
                cacheEntry.SetOptions(cacheOptions);
                return _innerRepository.GetAll();
            });
        }

        public Product GetById(int id)
        {
            return _cache.GetOrCreate($"{CacheKey}-{id}", cacheEntry =>
            {
                cacheEntry.SetOptions(cacheOptions);
                return _innerRepository.GetById(id);
            });
        }

        public Product GetByName(string name)
        {
            return _cache.GetOrCreate($"{CacheKey}-{name}", cacheEntry =>
            {
                cacheEntry.SetOptions(cacheOptions);
                return _innerRepository.GetByName(name);
            });
        }
    }
}
