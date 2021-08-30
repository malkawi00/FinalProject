using REIFinal.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
   public interface IContactUsService
    {
        List<ContactUs> GetAll(); //stored proc dbo.GetAll
        string Create(ContactUs contactUs);//stored proc dbo.Insert
        string Delete(ContactUs contactUs);//stored proc dbo.Delete
        ContactUs GetById(ContactUs contactUs);//stored proc dbo.Getbyid
    }
}
