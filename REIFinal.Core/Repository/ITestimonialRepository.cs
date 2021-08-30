using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface ITestimonialRepository
    {
        void Create(Testimonial testimonial);//stored proc dbo.Insert
        List<DtoTestimonial> GetAll(); //stored proc dbo.GetAll
        void Update(Testimonial testimonial);//stored proc dbo.Update
        void Delete(Testimonial testimonial);//stored proc dbo.Delete
        DtoTestimonial GetById(Testimonial testimonial);//stored proc dbo.Getbyid

    }
}
