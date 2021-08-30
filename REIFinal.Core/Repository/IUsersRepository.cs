using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface IUsersRepository
    {
        List<DtoUsers> GetAll(); //stored proc dbo.GetAll
        string Create(Users user);//stored proc dbo.Insert
        void Update(Users user);//stored proc dbo.Update
        void Delete(Users user);//stored proc dbo.Delete
        DtoUsers GetById(Users user);//stored proc dbo.Getbyid
        Users CheckUser(Users user);

    }
}
