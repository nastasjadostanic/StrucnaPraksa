using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        protected readonly TimeSheetDatabaseEntities context;
        private IDbSet<Role> Entities;
        public RoleRepository()
        {  
            context = new TimeSheetDatabaseEntities();
            Entities = context.Set<Role>();
        }
        public Result Add(Core.Model.Role role)
        {
            Role roleRepo = new Role
            {
                Id = role.Id,
                Name = role.Name,
            };
            try
            {
                Entities.Add(roleRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Core.Model.Role Get(int id)
        {
            var repoEntity = Entities.Find(id);
            return new Core.Model.Role(repoEntity.Id, repoEntity.Name);
        }
        public IEnumerable<Core.Model.Role> GetAll()
        {
            var repoEntites = Entities.ToList();
            var entities = new List<Core.Model.Role> { };
            foreach (Role element in repoEntites)
            {
                entities.Add(new Core.Model.Role(element.Id, element.Name));
            }
            return entities;
        }
        public Result Remove(Core.Model.Role role)
        {
            try
            {
                Role roleRepo = Entities.Find(role.Id);
                Entities.Remove(roleRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result Update(int id,Core.Model.Role role)
        {
            try
            {
                Role roleRepo = Entities.Find(id);
                roleRepo.Name = role.Name;
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

