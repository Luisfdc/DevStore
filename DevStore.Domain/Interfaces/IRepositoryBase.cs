using System.Collections.Generic;

namespace DevStore.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity: class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void Delete(int id);
    }
}
