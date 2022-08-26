using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Core.Repositories;


namespace TimeSheet.Repository.Repositories
{
    public class ClientRepository :  IClientRepository
    {
        protected readonly TimeSheetDatabaseEntities context;
        private IDbSet<Client> Entities;
        public ClientRepository()
        {   
            context = new TimeSheetDatabaseEntities();
            Entities = context.Set<Client>();
        }
        public Result Add(Core.Model.Client client)
        {
            Client clientRepo = new Client
            {
                Id = client.Id,
                Name = client.Name,
                Address = client.Address,
                City = client.City,
                ZipCode = client.ZipCode,
                CountryId = client.CountryId, 
                IsDeleted = false
            };
        
            try
            {
                Entities.Add(clientRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Core.Model.Client Get(int id)
        {
            var repoEntity = Entities.Find(id);
            if (repoEntity.IsDeleted == false) 
            {
                return new Core.Model.Client(repoEntity.Id, repoEntity.Name, repoEntity.Address, repoEntity.City, repoEntity.ZipCode, repoEntity.CountryId);
            }
            return null;
        }
        public IEnumerable<Core.Model.Client> GetAll()
        {
            var repoEntites = Entities.Where(x => x.IsDeleted == false).ToList();
            var entities = new List<Core.Model.Client> { };
            foreach (Client element in repoEntites)
            {
                entities.Add(new Core.Model.Client(element.Id, element.Name, element.Address, element.City, element.ZipCode, element.CountryId));
            }
            return entities;
        }
        public Result Remove(Core.Model.Client client)
        {
            try
            {
                Client clientRepo = Entities.Find(client.Id);
                Entities.Remove(clientRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result SoftDelete(int id)
        {
            try
            {
                Client clientRepo = Entities.Find(id);
                clientRepo.IsDeleted = true;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result Update(int id,Core.Model.Client client)
        {
            try
            {
                Client clientRepo = Entities.Find(id);

                clientRepo.Name = client.Name;
                clientRepo.Address = client.Address;
                clientRepo.City = client.City;
                clientRepo.ZipCode = client.ZipCode;
                clientRepo.CountryId = client.CountryId;
                clientRepo.IsDeleted = client.IsDeleted;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public IEnumerable<Core.Model.Client> FilterAndSearch(string letter, string name) 
        {
            var repoEntites = Entities.Where(x =>  x.Name.StartsWith(letter) && x.IsDeleted==false && x.Name.Contains(name)).ToList();
            var entities = new List<Core.Model.Client> { };
            foreach (Client element in repoEntites)
            {
                entities.Add(new Core.Model.Client(element.Id, element.Name, element.Address, element.City, element.ZipCode, element.CountryId));   
            }
            return entities;
        }
    }
}

