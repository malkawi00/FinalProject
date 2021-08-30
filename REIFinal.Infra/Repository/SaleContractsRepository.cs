using Dapper;
using REIFinal.Core.Common;
using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace REIFinal.Infra.Repository
{
    public class SaleContractsRepository : ISaleContractsRepository
    {
        private readonly IDBContext DBContext;

        public SaleContractsRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Create(SaleContracts salecontracts)
        {
            var p = new DynamicParameters();
            salecontracts.Commission = salecontracts.TotalPayment * 0.05;
            p.Add("@ContractDate", salecontracts.ContractDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@TotalPayment", salecontracts.TotalPayment, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@Document", salecontracts.Document, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Commission", salecontracts.Commission, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@UserId", salecontracts.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@AdvertisementId", salecontracts.AdvertisementId, dbType: DbType.Int32, direction: ParameterDirection.Input);
           

            var result = DBContext.connection.ExecuteAsync("CreateSaleContracts", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(SaleContracts salecontracts)
        {
            var p = new DynamicParameters();
            p.Add("@Id", salecontracts.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("DeleteSaleContractsById", p, commandType: CommandType.StoredProcedure);
        }

        public List<DtoSaleContracts> GetAll()
        {
            IEnumerable<DtoSaleContracts> result = DBContext.connection.Query<DtoSaleContracts>
           ("GetAllSaleContracts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public DtoSaleContracts GetById(SaleContracts salecontracts)
        {
            var p = new DynamicParameters();
            p.Add("@Id", salecontracts.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Query<DtoSaleContracts>("GetSaleContractsById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();

        }

        public void Update(SaleContracts salecontracts)
        {
            var p = new DynamicParameters();
            salecontracts.Commission = salecontracts.TotalPayment * 0.05;
            p.Add("@Id", salecontracts.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ContractDate", salecontracts.ContractDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@TotalPayment", salecontracts.TotalPayment, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@Document", salecontracts.Document, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Commission", salecontracts.Commission, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@UserId", salecontracts.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@AdvertisementId", salecontracts.AdvertisementId, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DBContext.connection.ExecuteAsync("UpdateSaleContracts", p, commandType: CommandType.StoredProcedure);
        }
    }
}
