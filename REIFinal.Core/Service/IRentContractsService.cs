using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
   public interface IRentContractsService
    {
        List<DtoRentContracts> GetAll();
        string Create(RentContracts rentcontract);
        string Delete(RentContracts rentcontract);
        string Update(RentContracts rentcontract);
        DtoRentContracts GetById(RentContracts rentcontract);
    }
}
