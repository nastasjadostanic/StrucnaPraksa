using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using TimeSheet.Core.Repositories;
using CSharpFunctionalExtensions;

namespace TimeSheet.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class 
    {   
        protected readonly TimeSheetDatabaseEntities context;
        private IDbSet<TEntity> Entities;
        public Repository() 
        {   
            context = new TimeSheetDatabaseEntities();
            Entities = context.Set<TEntity>();
        }  
        public Result Add(TEntity entity)
        {     
            try
            {
                Entities.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);

            }
            return Result.Success();
        }
        public TEntity Get(int id)
        {
            return Entities.Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }
        public Result Remove(TEntity entity)
        {
            try
            {
                Entities.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result Update(int id,TEntity entity)
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
    }
}
