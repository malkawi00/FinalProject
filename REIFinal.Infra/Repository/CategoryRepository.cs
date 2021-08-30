using Dapper;
using REIFinal.Core.Common;
using REIFinal.Core.Data;
using REIFinal.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace REIFinal.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDBContext DBContext;

        public CategoryRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Create(Category category)
        {
            var p = new DynamicParameters();

            p.Add("@CategoryName", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@DateCreated", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("CreateCategory", p, commandType: CommandType.StoredProcedure);
        
        }

       
        public void Delete(Category category)
        {
            var p = new DynamicParameters();
            p.Add("@Id", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("DeleteCategoryById", p, commandType: CommandType.StoredProcedure);
        }

        public List<Category> GetAll()
        {
            IEnumerable<Category> result = DBContext.connection.Query<Category>
            ("GetAllCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Category GetById(Category category)
        {
            var p = new DynamicParameters();
            p.Add("@Id", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Query<Category>("GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void Update(Category category)
        {
            var p = new DynamicParameters();
            p.Add("@Id", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CategoryName", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@DateCreated", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = DBContext.connection.Execute("UpdateCategory", p, commandType: CommandType.StoredProcedure);
        }
    }
}
