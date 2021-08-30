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
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            this.advertisementService = advertisementService;
        }

        [HttpPost]
        public string Create([FromBody] Advertisement advertisement)
        {
            var x = advertisementService.Create(advertisement);
           
                return "Sucessfully";
        }
        [HttpPut]
        public string update([FromBody] Advertisement advertisement)
        {
            return advertisementService.Update(advertisement);
        }

        [HttpDelete]
        [Route("DeleteAdvertisement")]
        public string Delete([FromBody] Advertisement advertisement)
        {
            return advertisementService.Delete(advertisement);
        }

        [HttpGet]
        public List<DtoAdvertisement> GetAll()
        {   
            return advertisementService.GetAll();
        }
        [HttpGet]
        [Route("GetAdvertisement")]
        public Advertisement GetById([FromBody] Advertisement advertisement)
        {
            return advertisementService.GetById(advertisement);
        }

    }
}
