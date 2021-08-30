using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
   public interface IUsersService
    {
        List<DtoUsers> GetAll();
        string Create(Users user);
        string Delete(Users user);
        string Update(Users user);
        DtoUsers GetById(Users user);
       
    }
}
