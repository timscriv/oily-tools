using OilyTools.Core.Interfaces.Repositories;
using Products.Core.Entities;

namespace Products.Core.Interfaces.Repositories
{
    public interface IHistoricalPriceRepository : IBaseReadOnlyRepository<int, HistoricalPrice>
    {
    }
}