using OilyTools.Core.Interfaces.UseCases;
using Products.Core.Common.Entities;
using Products.Core.Products.CreateProduct;

namespace Products.Core.Common.Interfaces.Products.CreateProduct
{
    public interface ICreateProductUseCase : IUseCase<Product, CreateProductUseCaseResponse>
    {
    }
}
