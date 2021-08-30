using REIFinal.Core.Data;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository contactUsReopsitory;

        public ContactUsService(IContactUsRepository contactUsReopsitory)
        {
            this.contactUsReopsitory = contactUsReopsitory;
        }

        public string Create(ContactUs contactUs)
        {
            contactUsReopsitory.Create(contactUs);
            return "Sucessfully";
        }

        public string Delete(ContactUs contactUs)
        {
            contactUsReopsitory.Delete(contactUs);
            return "Deleted";
        }

        public List<ContactUs> GetAll()
        {
            return contactUsReopsitory.GetAll();
        }

        public ContactUs GetById(ContactUs contactUs)
        {
            return contactUsReopsitory.GetById(contactUs);
        }
    }
}
