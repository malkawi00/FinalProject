using REIFinal.Core.Data;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryrepository;

        public CategoryService(ICategoryRepository categoryrepository)
        {
            this.categoryrepository = categoryrepository;
        }

        public string Create(Category category)
        {
            categoryrepository.Create(category);
            return "Sucessfully";
        }

       

        public string Delete(Category category)
        {
            categoryrepository.Delete(category);
            return "Deleted";
        }

        public List<Category> GetAll()
        {
            return categoryrepository.GetAll();
        }

        public Category GetById(Category category)
        {
            return categoryrepository.GetById(category);
        }

        public string Update(Category category)
        {
            categoryrepository.Update(category);
            return "Updated";
        }
    }
}
