using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface IRentContractsRepository
    {
        List<DtoRentContracts> GetAll(); //stored proc dbo.GetAll
        void Create(RentContracts rentcontract);//stored proc dbo.Insert
        void Update(RentContracts rentcontract);//stored proc dbo.Update
        void Delete(RentContracts rentcontract);//stored proc dbo.Delete
        DtoRentContracts GetById(RentContracts rentcontract);//stored proc dbo.Getbyid
    }
}
