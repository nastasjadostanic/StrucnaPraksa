using System.Collections.Generic;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Services
{
    public interface IClientService : IService<Client>
    {
        void SoftDelete(int id);
        IEnumerable<Client> FilterAndSearch(string letter, string name);
    }
}
