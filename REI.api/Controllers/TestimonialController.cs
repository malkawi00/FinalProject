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
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService  testimonialservice;

        public TestimonialController(ITestimonialService testimonialservice)
        {
            this.testimonialservice = testimonialservice;
        }
        [HttpPost]
        public string Create([FromBody] Testimonial testimonial)
        {
            return testimonialservice.Create(testimonial);
        }
        [HttpGet]
        public List<DtoTestimonial> GetAll()
        {
            return testimonialservice.GetAll();
        }

        [HttpGet]
        [Route("GetTestimonial")]
        public DtoTestimonial GetById([FromBody] Testimonial testimonial)
        {
            return testimonialservice.GetById(testimonial);
        }

        [HttpDelete]
        [Route("DeleteTestimonial")]
        public string Delete([FromBody] Testimonial testimonial)
        {
            return testimonialservice.Delete(testimonial);
        }
        [HttpPut]
        public string update([FromBody] Testimonial testimonial)
        {
            return testimonialservice.Update(testimonial);
        }
    }
}
