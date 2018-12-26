using OilyTools.Core.Interfaces.Repositories;
using Paginator;
using Products.Core.Entities;
using System.Collections.Generic;

namespace Products.Core.Interfaces.Repositories
{
    public interface IProductReadOnlyRepository : IBaseReadOnlyRepository<int, Product, CursorPagingRequest, CursorPagingMetadata>
    {
        Product GetByName(string name);
    }

    public interface IProductRepository : IBaseRepository<int, Product, CursorPagingRequest, CursorPagingMetadata>, IProductReadOnlyRepository
    {
    }
}
