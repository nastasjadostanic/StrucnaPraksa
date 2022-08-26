using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Repositories
{
    public class WorkRepository: IWorkRepository
    {
        protected readonly TimeSheetDatabaseEntities context;
        private IDbSet<Work> Entities;
        public WorkRepository()
        {  
            context = new TimeSheetDatabaseEntities();
            Entities = context.Set<Work>();
        }
        public Result Add(Core.Model.Work work)
        {
            Work workRepo = new Work
            {
                TeamMemberId = work.TeamMemberId,
                ProjectId = work.TeamMemberId,
                IsDeleted = false
            };
            try
            {
                Entities.Add(workRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Core.Model.Work Get(int teamMemberId, int projectId)
        {
            var repoEntity = Entities.Where(x => x.TeamMemberId == teamMemberId && x.ProjectId == projectId).FirstOrDefault();
            return new Core.Model.Work(repoEntity.TeamMemberId, repoEntity.ProjectId);
        }
        public IEnumerable<Core.Model.Work> GetAll()
        {
            var repoEntites = Entities.ToList();
            var entities = new List<Core.Model.Work> { };
            foreach (Work element in repoEntites)
            {
                entities.Add(new Core.Model.Work(element.TeamMemberId, element.ProjectId));
            }
            return entities;
        }
        public Result Remove(Core.Model.Work work)
        {
            try
            {
                Work workRepo = Entities.Find(work.TeamMemberId,work.ProjectId);
                Entities.Remove(workRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result Update(int teamMemberId, int projectId, Core.Model.Work work)
        {
            try
            {
                Work workRepo = Entities.Find(teamMemberId, projectId);
                workRepo.TeamMemberId = work.TeamMemberId;
                workRepo.ProjectId = work.ProjectId;
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
