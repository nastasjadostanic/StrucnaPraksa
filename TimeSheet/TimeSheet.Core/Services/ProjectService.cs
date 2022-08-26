using System.Collections.Generic;
using TimeSheet.Core.Model;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Core.Services
{
    public class ProjectService : IProjectService
    {
        public readonly IProjectRepository projectRepository;
        public ProjectService(IProjectRepository _projectRepository)
        {
            projectRepository = _projectRepository;
        }
        public IEnumerable<Project> GetAll()
        {
            return projectRepository.GetAll();
        }
        public Project Get(int id)
        {
            return projectRepository.Get(id);
        }
        public void Add(Project project)
        {
            projectRepository.Add(project);
        }
        public void Remove(Project project)
        {
            projectRepository.Remove(project);
        }
        public void Update(int id, Project project)
        {
            projectRepository.Update(id,project);
        }
        public void SoftDelete(int id)
        {
            projectRepository.SoftDelete(id);
        }
        public IEnumerable<Project> FilterAndSearch(string letter, string name)
        {
            return projectRepository.FilterAndSearch(letter,name);
        }
    }
}
