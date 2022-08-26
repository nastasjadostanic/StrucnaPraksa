using CSharpFunctionalExtensions;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Repositories
{
    public interface ITeamMemberRepository : IRepository<TeamMember>
    {
        Result SoftDelete(int id);
    }
}
