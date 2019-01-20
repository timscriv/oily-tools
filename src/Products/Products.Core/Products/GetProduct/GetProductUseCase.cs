using OilyTools.Core.Exceptions;
using Products.Core.Common.Entities;
using Products.Core.Common.Exceptions;
using Products.Core.Common.Interfaces.Products.GetProduct;
using Products.Core.Common.Interfaces.Repositories;
using System.Threading;

namespace Products.Core.Products.GetProduct
{
    public class GetProductUseCase : IGetProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Execute(GetProductUseCaseRequest request)
        {
            Thread.Sleep(1000); //Fake delay to show caching benefits

            if (request.Id.HasValue ^ string.IsNullOrEmpty(request.Name))
                throw new DomainException("Request must have either ID or name.");

            if (request.Id.HasValue)
            {
                return GetById(request.Id.Value);
            }
            else
            {
                return GetByName(request.Name);
            }
        }

        private Product GetByName(string name)
        {
            var product = _productRepository.GetByName(name);

            if (product == null)
                throw new ProductNotFoundException(name);

            return product;
        }

        private Product GetById(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
                throw new ProductNotFoundException(id);

            return product;
        }
    }
}
