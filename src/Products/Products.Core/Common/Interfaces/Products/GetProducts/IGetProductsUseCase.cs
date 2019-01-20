using OilyTools.Core.Interfaces.UseCases;
using Products.Core.Common.Entities;
using System.Collections.Generic;

namespace Products.Core.Common.Interfaces.Products.GetProducts
{
    public interface IGetProductsUseCase: IUseCase<IEnumerable<Product>>
    {
    }
}
