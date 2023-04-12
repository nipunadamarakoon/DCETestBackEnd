using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DCETest.DataAccessService.SqlDataService
{
    internal class SqlDataService : IDataService
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;
        private SqlTransaction _sqlTransaction;
        private SqlDataReader _sqlDataReader;
        //private static IConfigurationRoot Configuration { get; set; }

        public SqlDataService()
        {
            _sqlConnection = new SqlConnection();
            _sqlConnection.ConnectionString = ConnectionString;
            _sqlConnection.Open();
        }

        public string ConnectionString
        {
            get
            {
                try
                {
                    _connectionString = AppSettings.ConnectionString;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
                return _connectionString;
            }
        }     
        public override DbDataReader ExecuteReader(string spName, DbParameter[] sqlParameters, int? timeout = null)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _sqlConnection;
            command.CommandType = CommandType.StoredProcedure;
            if (timeout != null)
                command.CommandTimeout = Convert.ToInt32(timeout);
            command.CommandText = spName;
            command.Parameters.Clear();
            AddParameters(sqlParameters, command);
            if (_sqlTransaction != null)
                command.Transaction = _sqlTransaction;
            _sqlDataReader = command.ExecuteReader();
            return _sqlDataReader;
        }
       
        private void AddParameters(DbParameter[] dbParameters, SqlCommand command)
        {
            if (dbParameters != null)
            {
                foreach (DbParameter param in dbParameters)
                {
                    command.Parameters.Add(param);
                }
            }
        }

        public override void Dispose()
        {
            if (_sqlDataReader != null && !_sqlDataReader.IsClosed)
            {
                _sqlDataReader.Dispose();
            }
            if (_sqlConnection != null && _sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
            if (_sqlConnection != null)
                _sqlConnection.Dispose();
        }
    }
}
