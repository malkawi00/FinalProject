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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentservice;

        public PaymentController(IPaymentService paymentservice)
        {
            this.paymentservice = paymentservice;
        }
        [HttpPost]
        public string Create([FromBody] Payment payment)
        {
            return paymentservice.Create(payment);
        }
        [HttpGet]
        public List<Payment> GetAll()
        {
            return paymentservice.GetAll();
        }

        [HttpGet]
        [Route("GetPayment")]
        public Payment GetById([FromBody] Payment payment)
        {
            return paymentservice.GetById(payment);
        }

        [HttpDelete]
        [Route("DeletePayment")]
        public string Delete([FromBody] Payment payment)
        {
            return paymentservice.Delete(payment);
        }
        [HttpPut]
        public string update([FromBody] Payment payment)
        {
            return paymentservice.Update(payment);
        }
    }
}
