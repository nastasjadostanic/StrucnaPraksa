using CSharpFunctionalExtensions;
using System.Collections.Generic;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Result SoftDelete(int id);
        IEnumerable<Client> FilterAndSearch(string letter, string name);
    }
}
