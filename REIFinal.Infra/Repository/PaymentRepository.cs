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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDBContext DBContext;

        public PaymentRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Create(Payment payment)
        {
            var p = new DynamicParameters();

            p.Add("@PayAt", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@PaymentAmount", payment.PaymentAmount, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@RentContractId", payment.RentContractId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.connection.ExecuteAsync("CreatePayment", p, commandType: CommandType.StoredProcedure);

        }

        public void Delete(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("@Id", payment.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.ExecuteAsync("DeletePaymentById", p, commandType: CommandType.StoredProcedure);
        }
    

        public List<Payment> GetAll()
        {
            IEnumerable<Payment> result = DBContext.connection.Query<Payment>
           ("GetAllPayment", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Payment GetById(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("@Id", payment.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.connection.Query<Payment>("GetPaymentById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void Update(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("@Id", payment.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@PayAt", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@PaymentAmount", payment.PaymentAmount, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@RentContractId", payment.RentContractId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.connection.ExecuteAsync("UpdatePayment", p, commandType: CommandType.StoredProcedure);

        }
    }
}
