using REIFinal.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
   public interface IRoleService
    {
        List<Role> GetAll();
        string Create(Role role);
        string Update(Role role);
        string Delete(Role role);
        Role GetById(Role role);
    }
}
