using System.Collections.Generic;
using System.Web.Http;
using TimeSheet.Core.Services;

namespace TimeSheet.Api.Controllers
{
    public class ProjectController : ApiController
    {
        public readonly IProjectService projectService;
        public ProjectController(IProjectService _projectService)
        {
            projectService = _projectService;
        }
        // GET: api/Project
        public IEnumerable<Core.Model.Project> Get()
        {
            return projectService.GetAll();
        }

        // GET: api/Project/5
        public Core.Model.Project Get(int id)
        {
            return projectService.Get(id);
        }

        // POST: api/Project
        public Core.Model.Project Post([FromBody] Core.Model.Project value)
        {
            projectService.Add(value);
            return projectService.Get(value.Id);
        }

        // PUT: api/Project/5
        public Core.Model.Project Put(int id, [FromBody] Core.Model.Project value)
        {
            projectService.Update(id, value);
            return projectService.Get(value.Id);
        }

        // DELETE: api/Project/5
        public Core.Model.Project Delete(int id)
        {
            Core.Model.Project project = Get(id);
            projectService.Remove(project);
            return project;
        }
        // PUT:
        [Route("~/api/project/softdelete/{id}")]
        public Core.Model.Project Put(int id)
        {
            projectService.SoftDelete(id);
            return projectService.Get(id);
        }
        // GET: 
        [Route("~/api/project/filter/{letter}/search/{name}")]
        public IEnumerable<Core.Model.Project> Get(string letter, string name)
        {
            return projectService.FilterAndSearch(letter, name);
        }
    }
}
