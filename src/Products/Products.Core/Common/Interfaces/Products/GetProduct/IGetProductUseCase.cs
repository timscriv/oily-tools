using OilyTools.Core.Interfaces.UseCases;
using Products.Core.Common.Entities;
using Products.Core.Products.GetProduct;

namespace Products.Core.Common.Interfaces.Products.GetProduct
{
    public interface IGetProductUseCase: IUseCase<GetProductUseCaseRequest, Product>
    {
    }
}
