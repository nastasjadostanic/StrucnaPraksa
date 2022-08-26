using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Repositories
{
    public class TimeSheetEntryRepository : ITimeSheetEntryRepository
    {
        protected readonly TimeSheetDatabaseEntities context;
        private IDbSet<TimeSheetEntry> Entities;
        public TimeSheetEntryRepository()
        {
            context = new TimeSheetDatabaseEntities();
            Entities = context.Set<TimeSheetEntry>();
        }
        public Result Add(Core.Model.TimeSheetEntry timeSheetEntry)
        {
            TimeSheetEntry timeSheetEntryRepo = new TimeSheetEntry
            {
                Id = timeSheetEntry.Id,
                CategoryId = timeSheetEntry.CategoryId,
                ProjectId = timeSheetEntry.ProjectId,
                Description = timeSheetEntry.Description,
                Date = timeSheetEntry.Date,
                Time = timeSheetEntry.Time,
                Overtime = timeSheetEntry.Overtime
            };
            try
            {
                Entities.Add(timeSheetEntryRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Core.Model.TimeSheetEntry Get(int id)
        {
            var repoEntity = Entities.Find(id);
            return new Core.Model.TimeSheetEntry(repoEntity.Id, repoEntity.CategoryId, repoEntity.ProjectId, repoEntity.Description, repoEntity.Date, repoEntity.Time, (int)repoEntity.Overtime);
        }
        public IEnumerable<Core.Model.TimeSheetEntry> GetAll()
        {
            var repoEntites = Entities.ToList();
            var entities = new List<Core.Model.TimeSheetEntry> { };
            foreach (TimeSheetEntry element in repoEntites)
            {
                entities.Add(new Core.Model.TimeSheetEntry(element.Id, element.CategoryId, element.ProjectId, element.Description, element.Date, element.Time, (int)element.Overtime));
            }
            return entities;
        }
        public Result Remove(Core.Model.TimeSheetEntry timeSheetEntry)
        {
            try
            {
                TimeSheetEntry timeSheetEntryRepo = Entities.Find(timeSheetEntry.Id);
                Entities.Remove(timeSheetEntryRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result Update(int id, Core.Model.TimeSheetEntry timeSheetEntry)
        {
            try
            {
                TimeSheetEntry timeSheetEntryRepo = Entities.Find(id);

                timeSheetEntryRepo.CategoryId = timeSheetEntry.CategoryId;
                timeSheetEntryRepo.ProjectId = timeSheetEntry.ProjectId;
                timeSheetEntryRepo.TeamMemberId = timeSheetEntry.TeamMemberId;
                timeSheetEntryRepo.Description = timeSheetEntry.Description;
                timeSheetEntryRepo.Date = timeSheetEntry.Date;
                timeSheetEntryRepo.Time = timeSheetEntry.Time;
                timeSheetEntryRepo.Overtime = timeSheetEntry.Overtime;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public IEnumerable<Core.Model.TimeSheetEntry> Search(int teamMemberId, int projectId, int categoryId, DateTime startDate, DateTime endDate)
        {
            var repoEntities = Entities.Where(x => x.TeamMemberId == teamMemberId && x.ProjectId == projectId && x.CategoryId == categoryId && x.Date >= startDate && x.Date <= endDate).ToList();
            var entities = new List<Core.Model.TimeSheetEntry> { };
            foreach (TimeSheetEntry element in repoEntities)
            {
                entities.Add(new Core.Model.TimeSheetEntry(element.Id, element.CategoryId, element.ProjectId, element.Description, element.Date, element.Time, (int)element.Overtime)); 
            }
            return entities;
        }
    }
}
