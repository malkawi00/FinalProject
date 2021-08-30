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
    public class FavoritAdvController : ControllerBase
    {
        private readonly IFavoritAdvService favoritadvservice;

        public FavoritAdvController(IFavoritAdvService favoritadvservice)
        {
            this.favoritadvservice = favoritadvservice;
        }
        [HttpPost]
        public string Create([FromBody] FavoritAdv favoritadv)
        {
            return favoritadvservice.Create(favoritadv);
        }
        [HttpGet]
        public List<Dtofavoritadv> GetAll()
        {
            return favoritadvservice.GetAll();
        }

        [HttpGet]
        [Route("GetFavoritAdv")]
        public Dtofavoritadv GetById([FromBody] FavoritAdv favoritadv)
        {
            return favoritadvservice.GetById(favoritadv);
        }

        [HttpDelete]
        [Route("DeleteFavoritAdv")]
        public string Delete([FromBody] FavoritAdv favoritadv)
        {
            return favoritadvservice.Delete(favoritadv);
        }
       
    }
}
