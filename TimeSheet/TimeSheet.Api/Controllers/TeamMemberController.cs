using System.Collections.Generic;
using System.Web.Http;
using TimeSheet.Core.Services;

namespace TimeSheet.Api.Controllers
{
    public class TeamMemberController : ApiController
    {
        public readonly ITeamMemberService teamMemberService;
        public TeamMemberController(ITeamMemberService _teamMemberService)
        {
            teamMemberService = _teamMemberService;
        }

        // GET: api/TeamMember
        public IEnumerable<Core.Model.TeamMember> Get()
        {
            return teamMemberService.GetAll();
        }

        // GET: api/TeamMember/5
        public Core.Model.TeamMember Get(int id)
        {
            return teamMemberService.Get(id);
        }

        // POST: api/TeamMember
        public Core.Model.TeamMember Post([FromBody] Core.Model.TeamMember value)
        {
            teamMemberService.Add(value);
            return teamMemberService.Get(value.Id);
        }

        // PUT: api/TeamMember/5
        public Core.Model.TeamMember Put(int id, [FromBody] Core.Model.TeamMember value)
        {
            teamMemberService.Update(id,value);
            return teamMemberService.Get(value.Id);
        }

        // DELETE: api/TeamMember/5
        public Core.Model.TeamMember Delete(int id)
        {
            Core.Model.TeamMember teamMember = Get(id);
            teamMemberService.Remove(teamMember);
            return teamMember;
        }
        // PUT:
        [Route("~/api/teammember/softdelete/{id}")]
        public Core.Model.TeamMember Put(int id)
        {
            teamMemberService.SoftDelete(id);
            return teamMemberService.Get(id);
        }
    }
}
