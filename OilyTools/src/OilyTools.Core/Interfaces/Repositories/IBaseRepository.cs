using System.Collections.Generic;

namespace OilyTools.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TKey, TEntity>
    {
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity product);
        void Update(TEntity product);
        void Delete(TEntity product);
    }
}
