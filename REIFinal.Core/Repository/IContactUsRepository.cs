using REIFinal.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface IContactUsRepository
    {
        List<ContactUs> GetAll(); //stored proc dbo.GetAll
        void Create(ContactUs contactUs);//stored proc dbo.Insert
        void Delete(ContactUs contactUs);//stored proc dbo.Delete
        ContactUs GetById(ContactUs contactUs);//stored proc dbo.Getbyid
    }
}
