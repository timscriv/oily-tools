namespace OilyTools.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TKey, TEntity>
        : IBaseReadOnlyRepository<TKey, TEntity>
    {
        void Create(TEntity product);
        void Update(TEntity product);
        void Delete(TEntity product);
    }
}
