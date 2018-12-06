using Products.Core.Entities;

namespace Products.Core.Repositories
{
    public interface IHistoricalPriceRepository
    {
        HistoricalPrice Add(HistoricalPrice historicalPrice);
        void Save();
    }
}