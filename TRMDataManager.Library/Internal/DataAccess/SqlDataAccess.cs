using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T>(string storedProcedure, object parameters, string connectionStringName)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString(connectionStringName)))
            {
                List<T> rows = conn.Query<T>(
                    storedProcedure, 
                    parameters,  
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString(connectionStringName)))
            {
                conn.Execute(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
