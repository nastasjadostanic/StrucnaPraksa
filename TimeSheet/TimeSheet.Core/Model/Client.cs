
namespace TimeSheet.Core.Model
{
    public class Client
    {
        public Client(int id, string name, string address, string city, string zipCode, int countryId)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            ZipCode = zipCode;
            CountryId = countryId;
            
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
