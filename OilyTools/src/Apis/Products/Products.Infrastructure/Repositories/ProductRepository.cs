using Microsoft.EntityFrameworkCore;
using Products.Core.Entities;
using Products.Core.Repositories;
using Products.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Products.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsContext _context;

        public ProductRepository(ProductsContext context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);

            return product;
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public Product GetById(int id)
        {
            return _context.Products.SingleOrDefault(e => e.Id == id);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
