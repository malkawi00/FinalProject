using REIFinal.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface IPaymentRepository
    {
        List<Payment> GetAll(); //stored proc dbo.GetAll
        void Create(Payment payment);//stored proc dbo.Insert
        void Update(Payment payment);//stored proc dbo.Update
        void Delete(Payment payment);//stored proc dbo.Delete
        Payment GetById(Payment payment);//stored proc dbo.Getbyid
    }
}
