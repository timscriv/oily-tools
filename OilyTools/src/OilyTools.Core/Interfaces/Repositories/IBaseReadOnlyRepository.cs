using System.Collections.Generic;

namespace OilyTools.Core.Interfaces.Repositories
{
    public interface IBaseReadOnlyRepository<TKey, TEntity>
    {
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
    }
}
