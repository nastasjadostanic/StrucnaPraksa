
namespace TimeSheet.Core.Model
{
    public class Role
    {
        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
