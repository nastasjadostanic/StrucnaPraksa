using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.Core.Model;
using TimeSheet.Core.Repositories; 

namespace TimeSheet.Core.Services
{
    public class TimeSheetEntryService : ITimeSheetEntryService
    {
        public readonly ITimeSheetEntryRepository timeSheetEntryRepository;
        public TimeSheetEntryService(ITimeSheetEntryRepository _timeSheetEntryRepository)
        {
            timeSheetEntryRepository = _timeSheetEntryRepository;
        }
        public IEnumerable<TimeSheetEntry> GetAll()
        {
            return timeSheetEntryRepository.GetAll();
        }
        public TimeSheetEntry Get(int id)
        {
            return timeSheetEntryRepository.Get(id);
        }
        public void Add(TimeSheetEntry timeSheetEntry)
        {
            timeSheetEntryRepository.Add(timeSheetEntry);
        }
        public void Remove(TimeSheetEntry timeSheetEntry)
        {
            timeSheetEntryRepository.Remove(timeSheetEntry);
        }
        public void Update(int id,TimeSheetEntry timeSheetEntry)
        {
            timeSheetEntryRepository.Update(id,timeSheetEntry);
        }
        public IEnumerable<TimeSheetEntry> Search(int teamMemberId, int projectId, int categoryId, DateTime startDate, DateTime endDate)
        {
            return timeSheetEntryRepository.Search(teamMemberId,projectId,categoryId,startDate,endDate);
        }
    }
}
