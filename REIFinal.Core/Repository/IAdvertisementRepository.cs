using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface IAdvertisementRepository
    {
        List<DtoAdvertisement> GetAll(); //stored proc dbo.GetAll
        void Create(Advertisement advertisement);//stored proc dbo.Insert
        void Update(Advertisement advertisement);//stored proc dbo.Update
        void Delete(Advertisement advertisement);//stored proc dbo.Delete
        Advertisement GetById(Advertisement advertisement);//stored proc dbo.Getbyid
    }
}
