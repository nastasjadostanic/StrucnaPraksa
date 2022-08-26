
namespace TimeSheet.Core.Model
{
    public class TeamMember
    {
        public TeamMember(int id, string name, string username, string password, string email, int roleId, bool status)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            RoleId = roleId;
            Status = status;
        }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
