using OilyTools.Core.Interfaces.UseCases;
using Paginator;
using Products.Core.Entities;
using System.Collections.Generic;

namespace Products.Core.Interfaces.UseCases.Products
{
    public interface IGetProductsUseCase: IUseCase<IPagingResult<Product, CursorPagingMetadata>>
    {
    }
}
