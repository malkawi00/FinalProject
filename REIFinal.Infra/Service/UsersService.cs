using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
   public class UsersService:IUsersService
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

       

        public string Create(Users user)
        {
            var x = usersRepository.Create(user);
            if (x == "true")
            {
                return "Sucessfully";
            }
            if (x == "falseEmail")
            {
                return "Email must be example@gmail.com";
            }
            else {
                return "UserName OR Email OR PhoneNumber is  Already Use !";
            }

          
        }

        public string Delete(Users user)
        {
            usersRepository.Delete(user);
            return "Deleted";
        }

        public List<DtoUsers> GetAll()
        {
           return usersRepository.GetAll();

        }

        public DtoUsers GetById(Users user)
        {
           return usersRepository.GetById(user);
        }

        public string Update(Users user)
        {
            usersRepository.Update(user);
            return "Updated";
        }
    }
}
