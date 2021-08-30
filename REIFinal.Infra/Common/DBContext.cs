using Microsoft.Extensions.Configuration;
using REIFinal.Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace REIFinal.Infra.Common
{
  public  class DBContext : IDBContext
    {

        private DbConnection _connection;
        private readonly IConfiguration configuration;
        public DBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(configuration["ConnectionStrings:DBConnectionString"]);
                    _connection.Open();

                }
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }
    }
}
