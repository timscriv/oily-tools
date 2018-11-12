using OilyTools.Core.Entities;
using System.Collections.Generic;

namespace OilyTools.Core.Repositories
{
    public interface IBaseRepository<TKey, T> where T : BaseEntity
    {
        T GetById(TKey id);
        List<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
