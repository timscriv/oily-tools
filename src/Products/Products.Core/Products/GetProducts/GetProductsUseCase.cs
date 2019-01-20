using Products.Core.Common.Entities;
using Products.Core.Common.Interfaces.Products.GetProducts;
using Products.Core.Common.Interfaces.Repositories;
using System.Collections.Generic;

namespace Products.Core.Products.GetProducts
{
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IProductReadOnlyRepository _productRepository;

        public GetProductsUseCase(
            IProductReadOnlyRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Execute()
        {
            return _productRepository.GetBy();
        }
    }
}
