using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        protected readonly TimeSheetDatabaseEntities context;
        private IDbSet<Project> Entities;
        public ProjectRepository()
        {
            context = new TimeSheetDatabaseEntities();
            Entities = context.Set<Project>();
        }
        public Result Add(Core.Model.Project project)
        {
            Project projectRepo = new Project
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                ClientId = project.ClientId,
                TeamLeaderId = project.TeamLeaderId,
                IsDeleted = false
            };
            try
            {
                Entities.Add(projectRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();

        }
        public Core.Model.Project Get(int id)
        {
            var repoEntity = Entities.Find(id);
            if (repoEntity.IsDeleted == false)
            {

                return new Core.Model.Project(repoEntity.Id, repoEntity.Name, repoEntity.Description, repoEntity.ClientId, (int)repoEntity.TeamLeaderId);

            }
            else return null;
                
        }
        public IEnumerable<Core.Model.Project> GetAll()
        {
            var repoEntites = Entities.Where(x => x.IsDeleted == false).ToList();
            var entities = new List<Core.Model.Project> { };
            foreach (Project element in repoEntites)
            {
                entities.Add(new Core.Model.Project(element.Id, element.Name, element.Description, element.ClientId, (int)element.TeamLeaderId));
            }
            return entities;
        }
        public Result Remove(Core.Model.Project project)
        {
            try
            {
                Project projectRepo = Entities.Find(project.Id);
                Entities.Remove(projectRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result SoftDelete(int id)
        {
            try
            {
                Project projectRepo = Entities.Find(id);
                projectRepo.IsDeleted = true;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result Update(int id, Core.Model.Project project)
        {
            try
            {
                Project projectRepo = Entities.Find(id);

                projectRepo.Name = project.Name;
                projectRepo.Description = project.Description;
                projectRepo.ClientId = project.ClientId;
                projectRepo.TeamLeaderId = project.TeamLeaderId;
                projectRepo.IsDeleted = project.IsDeleted;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public IEnumerable<Core.Model.Project> FilterAndSearch(string letter, string name)
        {
            var repoEntites = Entities.Where(x =>  x.Name.StartsWith(letter) && x.IsDeleted == false && x.Name.Contains(name)).ToList();
            var entities = new List<Core.Model.Project> { };
            foreach (Project element in repoEntites)
            {
                entities.Add(new Core.Model.Project(element.Id, element.Name, element.Description, element.ClientId, (int)element.TeamLeaderId));
            }
            return entities;
        }
    }
}
