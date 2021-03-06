﻿using Microsoft.Extensions.Caching.Memory;
using OilyTools.Core.Interfaces.Specifications;
using Products.Core.Common.Entities;
using Products.Core.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Products.Infrastructure.EntityFramework.Repositories
{
    public class ProductCachedRepository : IProductReadOnlyRepository
    {
        private readonly ProductRepository _innerRepository;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "Products";

        public ProductCachedRepository(ProductRepository innerRepository, IMemoryCache cache, ProductRepository innerRepository2)
        {
            _cache = cache;
            _innerRepository = innerRepository;

            _cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
            _innerRepository = innerRepository2;
        }

        public IEnumerable<Product> GetBy(ISpecification<Product> specification = null)
        {
            //TODO: Make the specification cacheable
            return _cache.GetOrCreate(CacheKey, cacheEntry =>
            {
                cacheEntry.SetOptions(_cacheOptions);
                return _innerRepository.GetBy(specification);
            });
        }

        public Product GetById(int id)
        {
            return _cache.GetOrCreate($"{CacheKey}-{id}", cacheEntry =>
            {
                cacheEntry.SetOptions(_cacheOptions);
                return _innerRepository.GetById(id);
            });
        }

        public Product GetByName(string name)
        {
            return _cache.GetOrCreate($"{CacheKey}-{name}", cacheEntry =>
            {
                cacheEntry.SetOptions(_cacheOptions);
                return _innerRepository.GetByName(name);
            });
        }
    }
}
