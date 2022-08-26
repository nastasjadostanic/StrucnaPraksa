using System.Collections.Generic;
using System.Web.Http;
using TimeSheet.Core.Services;

namespace TimeSheet.Api.Controllers
{
    public class RoleController : ApiController
    {
        public readonly IRoleService roleService;
        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }
        // GET: api/Role
        public IEnumerable<Core.Model.Role> Get()
        {
            return roleService.GetAll();
        }

        // GET: api/Role/5
        public Core.Model.Role Get(int id)
        {
            return roleService.Get(id);
        }

        // POST: api/Role
        public void Post([FromBody] Core.Model.Role value)
        {
            roleService.Add(value);
        }

        // PUT: api/Role/5
        public void Put(int id, [FromBody] Core.Model.Role value)
        {
            roleService.Update(id,value);
        }

        // DELETE: api/Role/5
        public void Delete(int id)
        {
            Core.Model.Role role = Get(id);
            roleService.Remove(role);
        }
    }
}
