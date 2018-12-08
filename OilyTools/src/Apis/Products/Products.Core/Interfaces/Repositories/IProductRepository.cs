using OilyTools.Core.Interfaces.Repositories;
using Products.Core.Entities;
using System.Collections.Generic;

namespace Products.Core.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<int, Product>
    {
        Product GetByName(string name);
    }
}
