using Products.Core.Entities;
using System.Collections.Generic;

namespace Products.Core.Repositories
{
    public interface IProductRepository
    {
        Product GetById(int id);
        List<Product> GetAll();
        Product Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Save();
    }
}
