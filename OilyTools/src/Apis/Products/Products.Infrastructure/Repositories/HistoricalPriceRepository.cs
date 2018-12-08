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

        public HistoricalPrice Add(HistoricalPrice historicalPrice)
        {
           _context.HistoricalPrices.Add(historicalPrice);

           return historicalPrice;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}