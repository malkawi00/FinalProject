using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
   public interface ISaleContractsService
    {
        List<DtoSaleContracts> GetAll();
        string Create(SaleContracts salecontracts);
        string Delete(SaleContracts salecontracts);
        string Update(SaleContracts salecontracts);
        DtoSaleContracts GetById(SaleContracts salecontracts);
    }
}
