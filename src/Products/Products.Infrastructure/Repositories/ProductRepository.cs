using Microsoft.EntityFrameworkCore;
using OilyTools.Core.Interfaces.Specifications;
using Products.Core.Entities;
using Products.Core.Interfaces.Repositories;
using Products.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Products.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsContext _context;

        public ProductRepository(ProductsContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);

            _context.SaveChanges();
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

        public IEnumerable<Product> GetBy(ISpecification<Product> specification = null)
        {
            Thread.Sleep(1000); //Fake sleep to illustrate the caching benefits on bigger data

            return _context
                .Products
                .ToList();
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public Product GetByName(string name)
        {
            return _context.Products.SingleOrDefault(p => p.Name == name);
        }
    }
}
