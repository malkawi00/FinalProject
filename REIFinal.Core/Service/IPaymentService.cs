using REIFinal.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
   public interface IPaymentService
    {
        List<Payment> GetAll();
        string Create(Payment payment);
        string Delete(Payment payment);
        string Update(Payment payment);
        Payment GetById(Payment payment);
    }
}
