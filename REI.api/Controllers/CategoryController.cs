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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryservice;

        public CategoryController(ICategoryService categoryservice)
        {
            this.categoryservice = categoryservice;
        }

        [HttpPost]
        public string Create([FromBody] Category category)
        {
            return categoryservice.Create(category);
        }
     
       
        [HttpGet]
        public List<Category> GetAll()
        {
            return categoryservice.GetAll();
        }

        [HttpGet]
        [Route("GetCategory")]
        public Category GetById([FromBody] Category category)
        {
            return categoryservice.GetById(category);
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public string Delete([FromBody] Category category)
        {
            return categoryservice.Delete(category);
        }
        [HttpPut]
        public string update([FromBody] Category category)
        {
            return categoryservice.Update(category);
        }
    }
}
