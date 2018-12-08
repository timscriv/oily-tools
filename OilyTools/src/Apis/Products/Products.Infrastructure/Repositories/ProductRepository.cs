using Microsoft.EntityFrameworkCore;
using Products.Core.Entities;
using Products.Core.Interfaces.Repositories;
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

        public Product Create(Product product)
        {
            _context.Products.Add(product);

            _context.SaveChanges();

            return _context.Products.Find(product.Id);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context
                .Products
                .ToList();
        }

        public Product Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;

            _context.SaveChanges();

            return _context.Products.Find(product.Id);
        }

    }
}
