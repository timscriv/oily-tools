using Microsoft.EntityFrameworkCore;
using OilyTools.Core.Entities;
using OilyTools.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OilyTools.Core.Repositories
{
    public class ProductRepository : IBaseRepository<int, Product>
    {
        private readonly OilyToolsDbContext _context;

        public ProductRepository(OilyToolsDbContext context)
        {
            _context = context;
        }

        public Product Add(Product entity)
        {
            _context.Products.Add(entity);

            return entity;
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public Product GetById(int id)
        {
            return _context.Products.SingleOrDefault(e => e.Id == id);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
