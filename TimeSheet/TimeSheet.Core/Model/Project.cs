
namespace TimeSheet.Core.Model
{
    public class Project
    {
        public Project(int id, string name, string description, int clientId, int? teamLeaderId)
        {
            Id = id;
            Name = name;
            Description = description;
            ClientId = clientId;
            TeamLeaderId = teamLeaderId.GetValueOrDefault();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int TeamLeaderId { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
