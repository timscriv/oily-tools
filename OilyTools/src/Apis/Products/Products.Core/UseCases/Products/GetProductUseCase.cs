using System;
using OilyTools.Core.Exceptions;
using Products.Core.Entities;
using Products.Core.Exceptions;
using Products.Core.Interfaces.Repositories;
using Products.Core.Interfaces.UseCases.Products;

namespace Products.Core.UseCases.Products
{
    public class GetProductUseCase : IGetProductUseCase
    {
        private readonly IProductReadOnlyRepository _productRepository;

        public GetProductUseCase(IProductReadOnlyRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Execute(GetProductUseCaseRequest request)
        {
            if (request.Id.HasValue ^ string.IsNullOrEmpty(request.Name))
                throw new DomainException("Request must have either ID or name.");

            Product product;

            if (request.Id.HasValue)
            {
                product = GetById(request.Id.Value);
            }
            else
            {
                product = GetByName(request.Name);
            }

            return product;
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
