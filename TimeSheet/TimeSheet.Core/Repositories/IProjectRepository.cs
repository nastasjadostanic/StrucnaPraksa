using CSharpFunctionalExtensions;
using System.Collections.Generic;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Result SoftDelete(int id);
        IEnumerable<Project> FilterAndSearch(string letter, string name);
    }
}
