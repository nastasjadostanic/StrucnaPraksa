
namespace TimeSheet.Core.Model
{
    public class Country
    {
        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
