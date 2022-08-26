
namespace TimeSheet.Core.Model
{
    public class Category
    {
        public Category(int id, string name) 
        {
            Id = id;
            Name = name;
        }
        public Category()
        {
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
