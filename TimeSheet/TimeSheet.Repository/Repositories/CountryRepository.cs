using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Repositories
{
    public class CountryRepository :  ICountryRepository
    {
        protected readonly TimeSheetDatabaseEntities context;
        private IDbSet<Country> Entities;
        public CountryRepository()
        {
            context = new TimeSheetDatabaseEntities();
            Entities = context.Set<Country>();
        }

        public Result Add(Core.Model.Country country)
        {
            Country countryRepo = new Country
            {
                Id = country.Id,
                Name = country.Name
            };
            try
            {
                Entities.Add(countryRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Core.Model.Country Get(int id)
        {
            var repoEntity = Entities.Find(id);
            return new Core.Model.Country(repoEntity.Id, repoEntity.Name);
        }
        public IEnumerable<Core.Model.Country> GetAll()
        {
            var repoEntites = Entities.ToList();
            var entities = new List<Core.Model.Country> { };
            foreach (Country element in repoEntites)
            {
                entities.Add(new Core.Model.Country(element.Id, element.Name));
            }
            return entities;
        }
        public Result Remove(Core.Model.Country country)
        {
            try
            {
                Country countryRepo = Entities.Find(country.Id);
                Entities.Remove(countryRepo);                
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result Update(int id, Core.Model.Country country)
        {
            try
            {
                Country countryRepo = Entities.Find(id);
                countryRepo.Name = country.Name;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
    }
       
}
