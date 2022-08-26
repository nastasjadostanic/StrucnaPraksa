using System;
using System.Collections.Generic;
using System.Web.Http;
using TimeSheet.Core.Services;

namespace TimeSheet.Api.Controllers
{
    public class TimeSheetEntryController : ApiController
    {
        public readonly ITimeSheetEntryService timeSheetEntryService;
       
        public TimeSheetEntryController(ITimeSheetEntryService _timeSheetEntryService)
        {
            timeSheetEntryService = _timeSheetEntryService;
        }
        // GET: api/TimeSheetEntry
        public IEnumerable<Core.Model.TimeSheetEntry> Get()
        {
            return timeSheetEntryService.GetAll();
        }

        // GET: api/TimeSheetEntry/5
        public Core.Model.TimeSheetEntry Get(int id)
        {
            return timeSheetEntryService.Get(id);
        }

        // POST: api/TimeSheetEntry
        public Core.Model.TimeSheetEntry Post([FromBody] Core.Model.TimeSheetEntry value)
        {
            timeSheetEntryService.Add(value);
            return timeSheetEntryService.Get(value.Id);

        }

        // PUT: api/TimeSheetEntry/5
        public Core.Model.TimeSheetEntry Put(int id, [FromBody] Core.Model.TimeSheetEntry value)
        {
            timeSheetEntryService.Update(id,value);
            return timeSheetEntryService.Get(value.Id);
        }

        // DELETE: api/TimeSheetEntry/5
        public Core.Model.TimeSheetEntry Delete(int id)
        {
            Core.Model.TimeSheetEntry timeSheetEntry = Get(id);
            timeSheetEntryService.Remove(timeSheetEntry);
            return timeSheetEntry;
        }
        // GET: 
        [Route("~/api/timesheetentry/{teamMemberId}/{projectId}/{categoryId}/{startDate}/{endDate}")]
        public IEnumerable<Core.Model.TimeSheetEntry> Get(int teamMemberId, int projectId, int categoryId, DateTime startDate, DateTime endDate)
        {
            return timeSheetEntryService.Search(teamMemberId, projectId, categoryId, startDate, endDate);
        }
    }
}
