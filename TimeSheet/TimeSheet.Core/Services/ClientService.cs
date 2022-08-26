using System.Collections.Generic;
using TimeSheet.Core.Model;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Core.Services
{
    public class ClientService : IClientService
    {
        public readonly IClientRepository clientRepository;
        public ClientService(IClientRepository _clientRepository)
        {
            clientRepository = _clientRepository;
        }
        public IEnumerable<Client> GetAll()
        {
            return clientRepository.GetAll();
        }
        public Client Get(int id)
        {
            return clientRepository.Get(id);
        }
        public void Add(Client client)
        {
            clientRepository.Add(client);
        }
        public void Remove(Client client)
        {
            clientRepository.Remove(client);
        }
        public void Update(int id,Client client)
        {
            clientRepository.Update(id,client);
        }
        public void SoftDelete(int id)
        {
            clientRepository.SoftDelete(id);
        }
        public IEnumerable<Client> FilterAndSearch(string letter, string name)
        {
            return clientRepository.FilterAndSearch(letter, name);
        }
    }
}
