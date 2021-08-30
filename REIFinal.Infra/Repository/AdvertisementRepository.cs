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
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly IDBContext DBContext;

        public AdvertisementRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }
      
        public void Create(Advertisement advertisement)
        {
            var newImg = "";
            foreach (var item in advertisement.arrImageSrc)
            {
                newImg = newImg + item + ",";
            }

            var p = new DynamicParameters();
            p.Add("@Status", advertisement.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@IsActive", advertisement.IsActive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@IsValid", advertisement.IsValid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@lat", advertisement.lat, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@lin", advertisement.lin, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@CategoryId", advertisement.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserId", advertisement.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Floor", advertisement.Floor, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@NumOfBathrooms", advertisement.NumOfBathrooms, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@NumOfRooms", advertisement.NumOfRooms, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Age", advertisement.Age, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SurfaceArea", advertisement.SurfaceArea, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Description", advertisement.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@AdvTitle", advertisement.AdvTitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Price", advertisement.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@Furnished", advertisement.Furnished, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@AdvertisementId", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@LandArea", advertisement.LandArea, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@NumOfFloor", advertisement.NumOfFloor, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ModifyAt", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@ImageSrc", newImg, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DBContext.connection.ExecuteAsync("CreateAdvertisement", p, commandType: CommandType.StoredProcedure);
           
        }

        public void Update(Advertisement advertisement)
        {
            var newImg = "";
            foreach (var item in advertisement.ImageSrc)
            {
                newImg = newImg + item + ",";
            }
            advertisement.ModifyAt = DateTime.Now;
            var p = new DynamicParameters();
            p.Add("@Id", advertisement.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Status", advertisement.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@IsActive", advertisement.IsActive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@IsValid", advertisement.IsValid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@lat", advertisement.lat, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@lin", advertisement.lin, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@CategoryId", advertisement.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserId", advertisement.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Floor", advertisement.Floor, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@NumOfBathrooms", advertisement.NumOfBathrooms, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@NumOfRooms", advertisement.NumOfRooms, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Age", advertisement.Age, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SurfaceArea", advertisement.SurfaceArea, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Description", advertisement.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@AdvTitle", advertisement.AdvTitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Price", advertisement.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@ModifyAt", advertisement.ModifyAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@Furnished", advertisement.Furnished, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@AdvertisementId", advertisement.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@LandArea", advertisement.LandArea, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@NumOfFloor", advertisement.NumOfFloor, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ImageSrc", newImg, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DBContext.connection.ExecuteAsync("UpdateAdvertisement", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(Advertisement advertisement)
        {
            var p = new DynamicParameters();
            p.Add("@Id", advertisement.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Execute("DeleteAdvertisementById", p, commandType: CommandType.StoredProcedure);
        }

        public List<DtoAdvertisement> GetAll()
        {
            IEnumerable<DtoAdvertisement> result = DBContext.connection.Query<DtoAdvertisement>
            ("GetAllAdvertisement", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Advertisement GetById(Advertisement advertisement)
        {
            var p = new DynamicParameters();
            p.Add("@Id", advertisement.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CategoryId", advertisement.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.connection.Query<Advertisement>("GetAdvertisementById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        
    }
    }
