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
using System.Text.RegularExpressions;

namespace REIFinal.Infra.Repository
{
   public class UsersRepository : IUsersRepository
    {
        private readonly IDBContext DBContext;

        public UsersRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public Users CheckUser(Users user)
        {
            var p = new DynamicParameters();
            p.Add("@Username", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PhoneNumber", user.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DBContext.connection.Query<Users>("CheckUser", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public string Create(Users user)
        {

            var p = new DynamicParameters();
           
            p.Add("@FirstName", user.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
             p.Add("@LastName", user.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
             p.Add("@PhoneNumber", user.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
             p.Add("@Address", user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
             p.Add("@ProfilePic", user.ProfilePic, dbType: DbType.String, direction: ParameterDirection.Input);
             p.Add("@Username", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            
             p.Add("@Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
             p.Add("@UserId", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //test
            var stringToTest = user.Email;
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";


            //check first string
            if (Regex.IsMatch(stringToTest, pattern))
            {
                p.Add("@Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            }
            else {
                return "falseEmail";
            }
            //end

            var resultCheck = CheckUser(user);
            if (resultCheck == null)
            {
                var result = DBContext.connection.ExecuteAsync("CreateUser", p, commandType: CommandType.StoredProcedure);
                return "true";
            }
            else {
                return "false";
            }
            
        }

        public void Delete(Users user)
        {
            var p = new DynamicParameters();
            p.Add("@Id", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("DeleteUserById", p, commandType: CommandType.StoredProcedure);
        }

        public List<DtoUsers> GetAll()
        {
            IEnumerable<DtoUsers> result = DBContext.connection.Query<DtoUsers>
            ("GetAllUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public DtoUsers GetById(Users user)
        {
            var p = new DynamicParameters();
            p.Add("@Id", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Query<DtoUsers>("GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void Update(Users user)
        {
            var p = new DynamicParameters();
            p.Add("@Id", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@FirstName", user.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastName", user.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PhoneNumber", user.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Address", user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ProfilePic", user.ProfilePic, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.connection.Execute("UpdateUser", p, commandType: CommandType.StoredProcedure);
        }
    }
}
