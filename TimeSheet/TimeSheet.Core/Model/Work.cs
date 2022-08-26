
namespace TimeSheet.Core.Model
{
    public class Work
    {
        public Work(int teamMemberId, int projectId)
        {
            TeamMemberId = teamMemberId;
            ProjectId = projectId;
        }
        public int TeamMemberId { get; set; }
        public int ProjectId { get; set; }
    }
}
