using System.Collections.Generic;
using System.Web.Http;
using TimeSheet.Core.Services;

namespace TimeSheet.Api.Controllers
{
    public class ClientController : ApiController
    {
        public readonly IClientService clientService;
        public ClientController(IClientService _clientService)
        {
            clientService = _clientService;
        }
        // GET: api/Client
        public IEnumerable<Core.Model.Client> Get()
        {
            return clientService.GetAll();
        }

        // GET: api/Client/5
        public Core.Model.Client Get(int id)
        {
            return clientService.Get(id);
        }

        // POST: api/Client
        public Core.Model.Client Post([FromBody] Core.Model.Client value)
        {
            clientService.Add(value);
            return clientService.Get(value.Id);
        }

        // PUT: api/Client/5
        public Core.Model.Client Put(int id, [FromBody] Core.Model.Client value)
        {
            clientService.Update(id,value);
            return clientService.Get(value.Id);
        }

        // DELETE: api/Client/5
        public Core.Model.Client Delete(int id)
        {
            Core.Model.Client client = Get(id);
            clientService.Remove(client);
            return client;
        }

        // PUT: 
        [Route("~/api/client/softdelete/{id}")]
        public void Put(int id)
        {
            clientService.SoftDelete(id);
        }
        // GET: 
        [Route("~/api/client/filter/{letter}/search/{name}")]
        public IEnumerable<Core.Model.Client> Get(string letter, string name)
        {
            return clientService.FilterAndSearch(letter,name);
        }
    }
}
