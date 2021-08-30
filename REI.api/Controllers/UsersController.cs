using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        [HttpPost]
        public string Create([FromBody] Users user)
        {
            return usersService.Create(user);
        }
        [HttpGet]
        public List<DtoUsers> GetAll()
        {
            return usersService.GetAll();
        }
        
        [HttpGet]
        [Route("GetUser")]
        public DtoUsers GetById([FromBody] Users user)
        {
            return usersService.GetById(user);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public string Delete([FromBody] Users user)
        {
            return usersService.Delete(user);
        }
        [HttpPut]
        public string update([FromBody] Users user)
        {
            return usersService.Update(user);
        }

    }
}
