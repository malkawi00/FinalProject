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
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDBContext DBContext;

        public TestimonialRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Create(Testimonial testimonial)
        {
            var p = new DynamicParameters();

            p.Add("@Title", testimonial.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Massege", testimonial.Massege, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@IsActive",0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserId", testimonial.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.connection.ExecuteAsync("CreateTestimonial", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("@Id", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("DeleteTestimonialById", p, commandType: CommandType.StoredProcedure);
        }

        public List<DtoTestimonial> GetAll()
        {
            IEnumerable<DtoTestimonial> result = DBContext.connection.Query<DtoTestimonial>
            ("GetAllTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public DtoTestimonial GetById(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("@Id", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Query<DtoTestimonial>("GetTestimonialById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void Update(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("@Id", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@IsActive", testimonial.IsActive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Execute("UpdateTestimonial", p, commandType: CommandType.StoredProcedure);

        }
    }
}
