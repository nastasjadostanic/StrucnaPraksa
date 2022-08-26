using System.Collections.Generic;
using TimeSheet.Core.Repositories;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        public readonly ITeamMemberRepository teamMemberRepository;
        public TeamMemberService(ITeamMemberRepository _teamMemberRepository)
        {
            teamMemberRepository = _teamMemberRepository;
        }
        public IEnumerable<TeamMember> GetAll()
        {
            return teamMemberRepository.GetAll();
        }
        public TeamMember Get(int id)
        {
            return teamMemberRepository.Get(id);
        }
        public void Add(TeamMember teamMember)
        {
            teamMemberRepository.Add(teamMember);
        }
        public void Remove(TeamMember teamMember)
        {
            teamMemberRepository.Remove(teamMember);
        }
        public void Update(int id, TeamMember teamMember)
        {
            teamMemberRepository.Update(id,teamMember);
        }
        public void SoftDelete(int id)
        {
            teamMemberRepository.SoftDelete(id);
        }
    }
}
