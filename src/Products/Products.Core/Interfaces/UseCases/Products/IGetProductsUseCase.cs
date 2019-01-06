using OilyTools.Core.Interfaces.UseCases;
using Products.Core.Entities;
using System.Collections.Generic;

namespace Products.Core.Interfaces.UseCases.Products
{
    public interface IGetProductsUseCase: IUseCase<IEnumerable<Product>>
    {
    }
}
