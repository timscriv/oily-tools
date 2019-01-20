using OilyTools.Core.Interfaces.Repositories;
using Products.Core.Common.Entities;

namespace Products.Core.Common.Interfaces.Repositories
{
    public interface IProductReadOnlyRepository : IBaseReadOnlyRepository<int, Product>
    {
        Product GetByName(string name);
    }

    public interface IProductRepository : IBaseRepository<int, Product>, IProductReadOnlyRepository
    {
    }
}
