using System;
using System.Collections.Generic;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Services
{
    public interface ITimeSheetEntryService : IService<TimeSheetEntry>
    {
        IEnumerable<TimeSheetEntry> Search(int teamMemberId, int projectId, int categoryId, DateTime startDate, DateTime endDate);
    }
}
