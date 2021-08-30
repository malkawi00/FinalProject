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
    public class SaleContractsController : ControllerBase
    {
        private readonly ISaleContractsService salecontractsservice;

        public SaleContractsController(ISaleContractsService salecontractsservice)
        {
            this.salecontractsservice = salecontractsservice;
        }
        [HttpPost]
        public string Create([FromBody] SaleContracts salecontract)
        {
            return salecontractsservice.Create(salecontract);
        }
        [HttpGet]
        public List<DtoSaleContracts> GetAll()
        {
            return salecontractsservice.GetAll();
        }

        [HttpGet]
        [Route("GetSaleContract")]
        public DtoSaleContracts GetById([FromBody] SaleContracts salecontract)
        {
            return salecontractsservice.GetById(salecontract);
        }

        [HttpDelete]
        [Route("DeleteSaleContract")]
        public string Delete([FromBody] SaleContracts salecontract)
        {
            return salecontractsservice.Delete(salecontract);
        }
        [HttpPut]
        public string update([FromBody] SaleContracts salecontract)
        {
            return salecontractsservice.Update(salecontract);
        }

    }
}
