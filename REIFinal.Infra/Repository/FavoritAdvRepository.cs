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
    public class FavoritAdvRepository : IFavoritAdvRepository
    {
        private readonly IDBContext DBContext;

        public FavoritAdvRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Create(FavoritAdv favoritadv)
        {
            var p = new DynamicParameters();

            p.Add("@DateCreated",DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@UserId", favoritadv.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@AdvertisementId", favoritadv.AdvertisementId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.connection.ExecuteAsync("CreateFavoritAdv", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(FavoritAdv favoritadv)
        {
            var p = new DynamicParameters();
            p.Add("@Id", favoritadv.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("DeleteFavoritAdvById", p, commandType: CommandType.StoredProcedure);
        }

        public List<Dtofavoritadv> GetAll()
        {
            IEnumerable<Dtofavoritadv> result = DBContext.connection.Query<Dtofavoritadv>
           ("GetAllFavoritAdv", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Dtofavoritadv GetById(FavoritAdv favoritadv)
        {
            var p = new DynamicParameters();
            p.Add("@Id", favoritadv.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Query<Dtofavoritadv>("GetFavoritAdvById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
    }
}
