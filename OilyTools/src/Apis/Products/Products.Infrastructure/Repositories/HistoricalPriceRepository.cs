using System.Collections.Generic;
using Products.Core.Entities;
using Products.Core.Interfaces.Repositories;
using Products.Infrastructure.Contexts;

namespace Products.Infrastructure.Repositories
{
    public class HistoricalPriceRepository : IHistoricalPriceRepository
    {
        private readonly ProductsContext _context;
        public HistoricalPriceRepository(ProductsContext context)
        {
            _context = context;
        }

        public void Create(HistoricalPrice product)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(HistoricalPrice product)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HistoricalPrice> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public HistoricalPrice GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(HistoricalPrice product)
        {
            throw new System.NotImplementedException();
        }
    }
}