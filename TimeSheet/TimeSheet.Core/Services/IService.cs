using System.Collections.Generic;

namespace TimeSheet.Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(int id,TEntity entity);
    }
}
