using System.Collections.Generic;
using System.Web.Http;
using TimeSheet.Core.Services;

namespace TimeSheet.Api.Controllers
{
    public class WorkController : ApiController
    {
        public readonly IWorkService workService;
        public WorkController(IWorkService _workService)
        {
            workService = _workService;
        }
        // GET: api/Work
        public IEnumerable<Core.Model.Work> Get()
        {
            return workService.GetAll();
        }

        // GET: api/Work/5
        [Route("~/api/work/{teamMemberId}/{projectId}")]
        public Core.Model.Work Get(int teamMemberId, int projectId)
        {
            return workService.Get(teamMemberId,projectId);
        }

        // POST: api/Work
        public Core.Model.Work Post([FromBody] Core.Model.Work value)
        {
            workService.Add(value);
            return workService.Get(value.TeamMemberId,value.ProjectId);
        }

        // PUT: api/Work/5
        public Core.Model.Work Put(int teamMemberId, int projectid, [FromBody] Core.Model.Work value)
        {
            workService.Update(teamMemberId,projectid, value);
            return workService.Get(value.TeamMemberId, value.ProjectId);
        }

        // DELETE: api/Work/5
        public Core.Model.Work Delete(int teamMemberId, int projectId)
        {
            Core.Model.Work work = Get(teamMemberId, projectId);
            workService.Remove(work);
            return work;
        }
    }
}
