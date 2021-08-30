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
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IDBContext DBContext;

        public ContactUsRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Create(ContactUs contactUs)
        {
            var p = new DynamicParameters();

            p.Add("@Name", contactUs.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Email", contactUs.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Massege", contactUs.Massege, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@DateCreate", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = DBContext.connection.ExecuteAsync("CreateContactUs", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(ContactUs contactUs)
        {
            var p = new DynamicParameters();
            p.Add("@Id", contactUs.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("DeleteContactUsById", p, commandType: CommandType.StoredProcedure);
        }

        public List<ContactUs> GetAll()
        {
            IEnumerable<ContactUs> result = DBContext.connection.Query<ContactUs>
             ("GetAllContactUs", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ContactUs GetById(ContactUs contactUs)
        {
            var p = new DynamicParameters();
            p.Add("@Id", contactUs.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Query<ContactUs>("GetContactUsById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
    }
}
