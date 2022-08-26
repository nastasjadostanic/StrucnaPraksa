using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Repositories
{
    public class TeamMemberRepository :  ITeamMemberRepository
    {
        protected readonly TimeSheetDatabaseEntities context;
        private IDbSet<TeamMember> Entities;
        public TeamMemberRepository()
        {
            context = new TimeSheetDatabaseEntities();
            Entities = context.Set<TeamMember>();
        }
        public Result Add(Core.Model.TeamMember teamMember)
        {
            TeamMember teamMemberRepo = new TeamMember
            {
                Id = teamMember.Id,
                Name = teamMember.Name,
                Username = teamMember. Username,
                Password = teamMember.Password,
                Email = teamMember.Email,
                RoleId = teamMember.RoleId,
                Status = teamMember.Status,
                IsDeleted = false
            };
            try
            {
                Entities.Add(teamMemberRepo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Core.Model.TeamMember Get(int id)
        {
            var repoEntity = Entities.Find(id);
            if (repoEntity.IsDeleted == false)
            {
                return new Core.Model.TeamMember(repoEntity.Id, repoEntity.Name, repoEntity.Username, repoEntity.Password, repoEntity.Email, repoEntity.RoleId, repoEntity.Status);
            }
            else return null;
        }
        public IEnumerable<Core.Model.TeamMember> GetAll()
        {
            var repoEntites = Entities.Where(x => x.IsDeleted == false).ToList();
            var entities = new List<Core.Model.TeamMember> { };
            foreach (TeamMember element in repoEntites) 
            {
                entities.Add(new Core.Model.TeamMember(element.Id, element.Name, element.Username, element.Password, element.Email, element.RoleId, element.Status));
            }
            return entities;
        }
        public Result Remove(Core.Model.TeamMember teamMember)
        {
            try
            {
                TeamMember teamMemberRepo = Entities.Find(teamMember.Id);
                Entities.Remove(teamMemberRepo);
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
                TeamMember teamMemberRepo = Entities.Find(id);
                teamMemberRepo.IsDeleted = true;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Failure("Exception occured, exception message: " + ex.Message);
            }
            return Result.Success();
        }
        public Result Update(int id, Core.Model.TeamMember teamMember)
        {
            try
            {
                TeamMember teamMemberRepo = Entities.Find(id);

                teamMemberRepo.Name = teamMember.Name;
                teamMemberRepo.Username = teamMember.Username;
                teamMemberRepo.Password = teamMember.Password;
                teamMemberRepo.Email = teamMember.Email;
                teamMemberRepo.RoleId = teamMember.RoleId;
                teamMemberRepo.Status = teamMember.Status;
                teamMemberRepo.IsDeleted = teamMember.IsDeleted;

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
