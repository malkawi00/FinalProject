using REIFinal.Core.Data;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public string Create(Role role)
        {
            roleRepository.Create(role);
            return "Sucessfully";
        }

        public string Delete(Role role)
        {
            roleRepository.Delete(role);
            return "Deleted";
        }

        public List<Role> GetAll()
        {
            return roleRepository.GetAll();
        }

        public Role GetById(Role role)
        {
            return roleRepository.GetById(role);
        }

        public string Update(Role role)
        {
            roleRepository.Update(role);
            return "Updated";
        }
    }
}
