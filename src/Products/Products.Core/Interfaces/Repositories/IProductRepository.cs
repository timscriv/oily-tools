using OilyTools.Core.Interfaces.Repositories;
using Products.Core.Entities;

namespace Products.Core.Interfaces.Repositories
{
    public interface IProductReadOnlyRepository : IBaseReadOnlyRepository<int, Product>
    {
        Product GetByName(string name);
    }

    public interface IProductRepository : IBaseRepository<int, Product>, IProductReadOnlyRepository
    {
    }
}
