using Products.Core.Common.DomainEvents;
using Products.Core.Common.Entities;
using Products.Core.Common.Interfaces.Products.CreateProduct;
using Products.Core.Common.Interfaces.Repositories;

namespace Products.Core.Products.CreateProduct
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
