using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
    public class SaleContractsService : ISaleContractsService
    {
        private readonly ISaleContractsRepository salecontractsrepository;

        public SaleContractsService(ISaleContractsRepository salecontractsrepository)
        {
            this.salecontractsrepository = salecontractsrepository;
        }

        public string Create(SaleContracts salecontracts)
        {
            salecontractsrepository.Create(salecontracts);
            return "Sucessfully";
        }

        public string Delete(SaleContracts salecontracts)
        {
            salecontractsrepository.Delete(salecontracts);
            return "Deleted";
        }

        public List<DtoSaleContracts> GetAll()
        {
           return salecontractsrepository.GetAll();
        }

        public DtoSaleContracts GetById(SaleContracts salecontracts)
        {
            return salecontractsrepository.GetById(salecontracts);
        }

        public string Update(SaleContracts salecontracts)
        {
            salecontractsrepository.Update(salecontracts);
            return "Updated";
        }
    }
}
