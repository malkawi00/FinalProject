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
    public class RentContractsController : ControllerBase
    {
        private readonly IRentContractsService rentcontractsservice;

        public RentContractsController(IRentContractsService rentcontractsservice)
        {
            this.rentcontractsservice = rentcontractsservice;
        }
        [HttpPost]
        public string Create([FromBody] RentContracts rentcontract)
        {
            return rentcontractsservice.Create(rentcontract);
        }
        [HttpGet]
        public List<DtoRentContracts> GetAll()
        {
            return rentcontractsservice.GetAll();
        }

        [HttpGet]
        [Route("GetRentContract")]
        public DtoRentContracts GetById([FromBody] RentContracts rentcontract)
        {
            return rentcontractsservice.GetById(rentcontract);
        }

        [HttpDelete]
        [Route("DeleteRentContract")]
        public string Delete([FromBody] RentContracts rentcontract)
        {
            return rentcontractsservice.Delete(rentcontract);
        }
        [HttpPut]
        public string update([FromBody] RentContracts rentcontract)
        {
            return rentcontractsservice.Update(rentcontract);
        }


    }
}
