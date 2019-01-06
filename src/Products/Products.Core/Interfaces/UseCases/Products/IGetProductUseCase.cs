using OilyTools.Core.Interfaces.UseCases;
using Products.Core.Entities;
using Products.Core.UseCases.Products;

namespace Products.Core.Interfaces.UseCases.Products
{
    public interface IGetProductUseCase: IUseCase<GetProductUseCaseRequest, Product>
    {
    }
}
