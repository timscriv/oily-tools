namespace OilyTools.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TKey, TEntity, TPagingRequest, TPagingMetadata> 
        : IBaseReadOnlyRepository<TKey, TEntity, TPagingRequest, TPagingMetadata>
    {
        void Create(TEntity product);
        void Update(TEntity product);
        void Delete(TEntity product);
    }
}
