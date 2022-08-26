using System.Collections.Generic;
using TimeSheet.Core.Model;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Core.Services
{
    public class CountryService : ICountryService
    {
        public readonly ICountryRepository countryRepository;
        public CountryService(ICountryRepository _countryRepository)
        {
            countryRepository = _countryRepository;
        }
        public IEnumerable<Country> GetAll()
        {
            return countryRepository.GetAll();
        }
        public Country Get(int id)
        {
            return countryRepository.Get(id);
        }
        public void Add(Country country)
        {
            countryRepository.Add(country);
        }
        public void Remove(Country country)
        {
            countryRepository.Remove(country);
        }
        public void Update(int id,Country country)
        {
            countryRepository.Update(id,country);
        }
    }
}
