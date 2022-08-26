using System.Collections.Generic;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Services
{
    public interface IProjectService : IService<Project>
    {
        void SoftDelete(int id);
        IEnumerable<Project> FilterAndSearch(string letter, string name);
    }
}
