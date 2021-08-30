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
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            this.contactUsService = contactUsService;
        }
        [HttpPost]
        public string Create([FromBody] ContactUs contactUs)
        {
            return contactUsService.Create(contactUs);
        }
        [HttpGet]
        public List<ContactUs> GetAll()
        {
            return contactUsService.GetAll();
        }

        [HttpGet]
        [Route("GetContactUs")]
        public ContactUs GetById([FromBody] ContactUs contactUs)
        {
            return contactUsService.GetById(contactUs);
        }

        [HttpDelete]
        [Route("DeleteContactUs")]
        public string Delete([FromBody] ContactUs contactUs)
        {
            return contactUsService.Delete(contactUs);
        }
     
    }
}
