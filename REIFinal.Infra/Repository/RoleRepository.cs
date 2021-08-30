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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDBContext DBContext;

        public RoleRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Create(Role role)
        {
            var p = new DynamicParameters();

            p.Add("@RoleName", role.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("CreateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(Role role)
        {
            var p = new DynamicParameters();
            p.Add("@Id", role.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("DeleteRoleById", p, commandType: CommandType.StoredProcedure);
        }

        public List<Role> GetAll()
        {
            IEnumerable<Role> result = DBContext.connection.Query<Role>
             ("GetAllRole", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetById(Role role)
        {
            var p = new DynamicParameters();
            p.Add("@Id", role.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Query<Role>("GetRoleById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void Update(Role role)
        {
            var p = new DynamicParameters();
            p.Add("@Id", role.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@RoleName", role.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DBContext.connection.Execute("UpdateRole", p, commandType: CommandType.StoredProcedure);
        }
    }
}
