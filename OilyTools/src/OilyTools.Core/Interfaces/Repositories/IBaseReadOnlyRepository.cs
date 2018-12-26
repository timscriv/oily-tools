using OilyTools.Core.Interfaces.Specifications;
using Paginator;

namespace OilyTools.Core.Interfaces.Repositories
{
    public interface IBaseReadOnlyRepository<TKey, TEntity, TPagingRequest, TPagingMetadata>
    {
        TEntity GetById(TKey id);
        IPagingResult<TEntity, TPagingMetadata> GetBy(ISpecification<TEntity> spec = null, TPagingRequest pagingRequest = default(TPagingRequest));
    }
}
