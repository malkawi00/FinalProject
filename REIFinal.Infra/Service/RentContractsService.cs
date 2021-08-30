using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
    public class RentContractsService : IRentContractsService
    {
        private readonly IRentContractsRepository rentcontractsrepository;

        public RentContractsService(IRentContractsRepository rentcontractsrepository)
        {
            this.rentcontractsrepository = rentcontractsrepository;
        }

        public string Create(RentContracts rentcontract)
        {
            rentcontractsrepository.Create(rentcontract);
            return "Sucessfully";
        }

        public string Delete(RentContracts rentcontract)
        {
            rentcontractsrepository.Delete(rentcontract);
            return "Deleted";
        }

        public List<DtoRentContracts> GetAll()
        {
            return rentcontractsrepository.GetAll();
        }

        public DtoRentContracts GetById(RentContracts rentcontract)
        {
           return rentcontractsrepository.GetById(rentcontract);
        }

        public string Update(RentContracts rentcontract)
        {
            rentcontractsrepository.Update(rentcontract);
            return "Updated";
        }
    }
}
