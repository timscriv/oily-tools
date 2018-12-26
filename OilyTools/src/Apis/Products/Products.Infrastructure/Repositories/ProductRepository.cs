using Microsoft.EntityFrameworkCore;
using OilyTools.Core.Interfaces;
using OilyTools.Core.Interfaces.Specifications;
using Paginator;
using Paginator.Cursors;
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

        public IPagingResult<Product, CursorPagingMetadata> GetBy(ISpecification<Product> specification = null, CursorPagingRequest pagingRequest = null)
        {
            Thread.Sleep(1000); //Fake sleep to illustrate the caching benefits on bigger data

            var cursor = new KeyCursor<Product, int>(0);

            var query = _context
                .Products;

            var options = new KeyCursorOptions<Product, int>(p => p.Id > 0, p => p.Id, 1);

            return cursor.ApplyCursor(query, options);
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
