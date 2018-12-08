using Products.Core.Entities;
using Products.Core.Interfaces.Repositories;
using Products.Core.Interfaces.UseCases.Products;
using System.Collections.Generic;

namespace Products.Core.UseCases.Products
{
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductsUseCase(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Execute()
        {
            return _productRepository.GetAll();
        }
    }
}
