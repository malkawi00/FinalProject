using REIFinal.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface ICategoryRepository
    {
        List<Category> GetAll(); //stored proc dbo.GetAll
        void Create(Category category);//stored proc dbo.Insert
        void Update(Category category);//stored proc dbo.Update
        void Delete(Category category);//stored proc dbo.Delete
        Category GetById(Category category);//stored proc dbo.Getbyid
  
    }
}
