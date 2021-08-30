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
    public class RentContractsRepository : IRentContractsRepository
    {
        private readonly IDBContext DBContext;

        public RentContractsRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Create(RentContracts rentcontract)
        {
            var p = new DynamicParameters();

            p.Add("@DateFrom", rentcontract.DateFrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@DateTo", rentcontract.DateTo, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@ExtraInformation", rentcontract.ExtraInformation, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Document", rentcontract.Document, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Paid", rentcontract.Paid, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@DateCreated", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@UserId", rentcontract.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@AdvertisementId", rentcontract.AdvertisementId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.connection.ExecuteAsync("CreateRentContracts", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(RentContracts rentcontract)
        {
            var p = new DynamicParameters();
            p.Add("@Id", rentcontract.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("DeleteRentContractsById", p, commandType: CommandType.StoredProcedure);
        }

        public List<DtoRentContracts> GetAll()
        {
            IEnumerable<DtoRentContracts> result = DBContext.connection.Query<DtoRentContracts>
            ("GetAllRentContracts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public DtoRentContracts GetById(RentContracts rentcontract)
        {
            var p = new DynamicParameters();
            p.Add("@Id", rentcontract.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Query<DtoRentContracts>("GetRentContractsById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void Update(RentContracts rentcontract)
        {
            var p = new DynamicParameters();
            p.Add("@Id", rentcontract.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@DateFrom", rentcontract.DateFrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@DateTo", rentcontract.DateTo, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@ExtraInformation", rentcontract.ExtraInformation, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Document", rentcontract.Document, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Paid", rentcontract.Paid, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@DateCreated", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@UserId", rentcontract.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@AdvertisementId", rentcontract.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.connection.ExecuteAsync("UpdateSaleContracts", p, commandType: CommandType.StoredProcedure);
        }
    }
}
