using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository testimonialrepository;

        public TestimonialService(ITestimonialRepository testimonialrepository)
        {
            this.testimonialrepository = testimonialrepository;
        }

        public string Create(Testimonial testimonial)
        {
            testimonialrepository.Create(testimonial);
            return "Sucessfully";
        }

        public string Delete(Testimonial testimonial)
        {
            testimonialrepository.Delete(testimonial);
            return "Deleted";
        }

        public List<DtoTestimonial> GetAll()
        {
            return testimonialrepository.GetAll();
        }

        public DtoTestimonial GetById(Testimonial testimonial)
        {
            return testimonialrepository.GetById(testimonial);
        }

        public string Update(Testimonial testimonial)
        {
            testimonialrepository.Update(testimonial);
            return "Updated";
        }
    }
}
