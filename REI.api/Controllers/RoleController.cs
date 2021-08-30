using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REIFinal.Core.Data;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        [HttpPost]
        public string Create([FromBody] Role role)
        {
            return roleService.Create(role);
        }
        [HttpGet]
        public List<Role> GetAll()
        {
            return roleService.GetAll();
        }

        [HttpGet]
        [Route("GetRole")]
        public Role GetById([FromBody] Role role)
        {
            return roleService.GetById(role);
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public string Delete([FromBody] Role role)
        {
            return roleService.Delete(role);
        }
        [HttpPut]
        public string update([FromBody] Role role)
        {
            return roleService.Update(role);
        }
    }
}
