using Products.Core.Entities;

namespace Products.Core.Interfaces.Repositories
{
    public interface IHistoricalPriceRepository
    {
        HistoricalPrice Add(HistoricalPrice historicalPrice);
        void Save();
    }
}