using CSharpFunctionalExtensions;
using System.Collections.Generic;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Repositories
{
    public interface IWorkRepository 
    {
        Work Get(int teamMemberId, int projectId);
        IEnumerable<Work> GetAll();
        Result Add(Work work);
        Result Remove(Work work);
        Result Update(int teamMemberId, int projectId , Work work);
    }
}
