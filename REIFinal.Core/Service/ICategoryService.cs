using REIFinal.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
   public interface ICategoryService
    {
        List<Category> GetAll();
        string Create(Category category);
        string Delete(Category category);
        string Update(Category category);
        Category GetById(Category category);
       
    }
}
