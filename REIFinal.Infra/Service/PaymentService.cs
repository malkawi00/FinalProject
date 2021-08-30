using REIFinal.Core.Data;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
  public  class PaymentService: IPaymentService
    {
        private readonly IPaymentRepository paymentrepository;

        public PaymentService(IPaymentRepository paymentrepository)
        {
            this.paymentrepository = paymentrepository;
        }

        public string Create(Payment payment)
        {
            paymentrepository.Create(payment);
            return "Sucessfully";
        }

        public string Delete(Payment payment)
        {
            paymentrepository.Delete(payment);
            return "Deleted";
        }

        public List<Payment> GetAll()
        {
            return paymentrepository.GetAll();
        }

        public Payment GetById(Payment payment)
        {
            return paymentrepository.GetById(payment);
        }

        public string Update(Payment payment)
        {
            paymentrepository.Update(payment);
            return "Updated";
        }
    }
}
