using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
   public interface ITestimonialService
    {
        List<DtoTestimonial> GetAll();
        string Create(Testimonial testimonial);
        string Delete(Testimonial testimonial);
        string Update(Testimonial testimonial);
        DtoTestimonial GetById(Testimonial testimonial);
    }
}
