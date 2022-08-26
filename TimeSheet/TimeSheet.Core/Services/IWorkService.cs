using System.Collections.Generic;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Services
{
    public interface IWorkService 
    {
        Work Get(int teamMemberId, int projectId);
        IEnumerable<Work> GetAll();
        void Add(Work work);
        void Remove(Work entity);
        void Update(int teamMemberId, int projectId, Work work);
    }
}
