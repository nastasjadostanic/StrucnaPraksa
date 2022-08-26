using System.Collections.Generic;
using System.Web.Http;
using TimeSheet.Core.Services;

namespace TimeSheet.Api.Controllers
{
    public class CountryController : ApiController
    {
        public readonly ICountryService countryService;
        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;
        }
        // GET: api/Country
        public IEnumerable<Core.Model.Country> Get()
        {
            return countryService.GetAll();
        }

        // GET: api/Country/5
        public Core.Model.Country Get(int id)
        {
            return countryService.Get(id);
        }

        // POST: api/Country
        public Core.Model.Country Post([FromBody] Core.Model.Country value)
        {
            countryService.Add(value);
            return countryService.Get(value.Id);
        }

        // PUT: api/Country/5
        public Core.Model.Country Put(int id, [FromBody] Core.Model.Country value)
        {
            countryService.Update(id,value);
            return countryService.Get(value.Id);
        }

        // DELETE: api/Country/5
        public Core.Model.Country Delete(int id)
        {
            Core.Model.Country country = Get(id);
            countryService.Remove(country);
            return country;
        }
    }
}
