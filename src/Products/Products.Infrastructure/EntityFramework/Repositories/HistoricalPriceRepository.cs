using OilyTools.Core.Interfaces.Specifications;
using Products.Core.Common.Entities;
using Products.Core.Common.Interfaces.Repositories;
using Products.Infrastructure.EntityFramework.Contexts;
using System.Collections.Generic;

namespace Products.Infrastructure.EntityFramework.Repositories
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

        public IEnumerable<HistoricalPrice> GetBy(ISpecification<HistoricalPrice> specification = null)
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