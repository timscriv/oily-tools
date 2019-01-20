using Microsoft.Extensions.Caching.Memory;
using Products.Core.Common.Entities;
using Products.Core.Common.Interfaces.Products.GetProduct;
using System;

namespace Products.Core.Products.GetProduct
{
    public class GetProductUseCaseCached : IGetProductUseCase
    {
        private readonly IMemoryCache _cache;
        private readonly GetProductUseCase _innerUseCase;
        private readonly MemoryCacheEntryOptions _cacheOptions;

        public GetProductUseCaseCached(GetProductUseCase innerUseCase, IMemoryCache cache)
        {
            _cache = cache;
            _innerUseCase = innerUseCase;

            _cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
        }

        public Product Execute(GetProductUseCaseRequest request)
        {
            // Since request is a ValueObject it can be used as a cacheKey
            // if it was a normal object this would never hit the cache
            return _cache.GetOrCreate(request, cacheEntry =>
            {
                cacheEntry.SetOptions(_cacheOptions);

                return _innerUseCase.Execute(request);
            });
        }
    }
}
