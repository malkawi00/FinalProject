using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface ISaleContractsRepository
    {
        List<DtoSaleContracts> GetAll(); //stored proc dbo.GetAll
        void Create(SaleContracts salecontracts);//stored proc dbo.Insert
        void Update(SaleContracts salecontracts);//stored proc dbo.Update
        void Delete(SaleContracts salecontracts);//stored proc dbo.Delete
        DtoSaleContracts GetById(SaleContracts salecontracts);//stored proc dbo.Getbyid
    }

}
