using System.Collections.Generic;
using TimeSheet.Core.Model;
using TimeSheet.Core.Repositories;

namespace TimeSheet.Core.Services
{
    public class RoleService : IRoleService
    {
        public readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository _roleRepository)
        {
            roleRepository = _roleRepository;
        }
        public IEnumerable<Role> GetAll()
        {
            return roleRepository.GetAll();
        }
        public Role Get(int id)
        {
            return roleRepository.Get(id);
        }
        public void Add(Role role)
        {
            roleRepository.Add(role);
        }
        public void Remove(Role role)
        {
            roleRepository.Remove(role);
        }
        public void Update(int id, Role role)
        {
            roleRepository.Update(id,role);
        }
    }
}
