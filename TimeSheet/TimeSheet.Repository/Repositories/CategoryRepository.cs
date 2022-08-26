using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Repository.Repositories
{
    public class CategoryRepository :  ICategoryRepository
    {
        protected readonly TimeSheetDatabaseEntities context;
        private IDbSet<Category> Entities;
        public CategoryRepository()
        {   
            context = new TimeSheetDatabaseEntities();
            Entities = context.Set<Category>();
        }
        public Result Add(Core.Model.Category category)
        {
            Category categoryRepo = new Category
            {
                Id = category.Id,
                Name = category.Name,
            };

            try
            {
                Entities.Add(categoryRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();

        }
        public Core.Model.Category Get(int id)
        {
            var repoEntity = Entities.Find(id);
            return new Core.Model.Category(repoEntity.Id, repoEntity.Name); 
        }
        public IEnumerable<Core.Model.Category> GetAll()
        {
            var repoEntites = Entities.ToList();
            var entities = new List<Core.Model.Category> { };
            foreach (Category element in repoEntites) 
            {
                entities.Add(new Core.Model.Category(element.Id, element.Name));
            }
            return entities;
        }
        public Result Remove(Core.Model.Category category)
        {
            try
            {
                Category categoryRepo = Entities.Find(category.Id);
                Entities.Remove(categoryRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result Update(int id,Core.Model.Category category)
        {
            try
            {
                Category categoryRepo = Entities.Find(id);
                categoryRepo.Name = category.Name;
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

