using REIFinal.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface IRoleRepository
    {
        List<Role> GetAll(); //stored proc dbo.GetAll
        void Create(Role role);//stored proc dbo.Insert
        void Update(Role role);//stored proc dbo.Update
        void Delete(Role role);//stored proc dbo.Delete
        Role GetById(Role role);//stored proc dbo.Getbyid
    }
}
