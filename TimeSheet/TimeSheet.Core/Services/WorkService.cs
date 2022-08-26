using System.Collections.Generic;
using TimeSheet.Core.Model;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Core.Services
{
    public class WorkService : IWorkService
    {
        public readonly IWorkRepository workRepository;
        public WorkService(IWorkRepository _workRepository)
        {
            workRepository = _workRepository;
        }
        public IEnumerable<Work> GetAll()
        {
            return workRepository.GetAll();
        }
        public Work Get(int teamMemberId, int projectId)
        {
            return workRepository.Get(teamMemberId,projectId);
        }
        public void Add(Work work)
        {
            workRepository.Add(work);
        }
        public void Remove(Work work)
        {
            workRepository.Remove(work);
        }
        public void Update(int projectId, int teamMemberId,Work work)
        {
            workRepository.Update(projectId,teamMemberId,work);
        }
    }
}
