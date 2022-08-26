using System.Collections.Generic;
using CSharpFunctionalExtensions;
namespace TimeSheet.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        Result Add(TEntity entity);
        Result Remove(TEntity entity);
        Result Update(int id, TEntity entity);
    }
}
