using OilyTools.Core.Interfaces.Repositories;
using Products.Core.Common.Entities;

namespace Products.Core.Common.Interfaces.Repositories
{
    public interface IHistoricalPriceRepository : IBaseReadOnlyRepository<int, HistoricalPrice>
    {
    }
}