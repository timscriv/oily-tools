using Products.Core.Entities;
using System.Collections.Generic;

namespace Products.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        Product Create(Product product);
        Product Update(Product product);
        void Delete(Product product);
    }
}
