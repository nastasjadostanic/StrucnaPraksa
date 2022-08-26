using TimeSheet.Core.Model;

namespace TimeSheet.Core.Services
{
    public interface ITeamMemberService : IService<TeamMember>
    {
        void SoftDelete(int id);
    }
}
