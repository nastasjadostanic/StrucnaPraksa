using System;
using System.Collections.Generic;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Repositories
{
    public interface ITimeSheetEntryRepository : IRepository<TimeSheetEntry>
    {
        IEnumerable<TimeSheetEntry> Search(int teamMemberId, int projectId, int categoryId, DateTime startDate, DateTime endDate);
    }
}
