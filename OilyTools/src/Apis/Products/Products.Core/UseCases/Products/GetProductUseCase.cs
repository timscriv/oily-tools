using Products.Core.Entities;
using Products.Core.Exceptions;
using Products.Core.Interfaces.Repositories;
using Products.Core.Interfaces.UseCases.Products;

namespace Products.Core.UseCases.Products
{
    public class GetProductUseCase : IGetProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Execute(int request)
        {
            var product = _productRepository.GetById(request);

            if (product == null)
                throw new ProductNotFoundException(request);

            return product;
        }
    }
}
