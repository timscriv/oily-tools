using Products.Core.DomainEvents;
using Products.Core.Entities;
using Products.Core.Interfaces.Repositories;
using Products.Core.Interfaces.UseCases.Products;
using System;

namespace Products.Core.UseCases.Products
{
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public CreateProductUseCase(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public CreateProductUseCaseResponse Execute(Product request)
        {
            request.Events.Add(new ProductCreatedEvent(request));
            _productRepository.Create(request);

            return new CreateProductUseCaseResponse(request.Id);
        }
    }
}
