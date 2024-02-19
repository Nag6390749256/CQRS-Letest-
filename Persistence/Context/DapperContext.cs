using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Persistence.Context
{
    public class DapperContext: IDapperContext
    {
        private string _dbConnectionString;
        public DapperContext()
        {
            _dbConnectionString = DBConnection.SqlConnection;
        }
        public async Task<T> ExceProcAsync<T>(string prodName,object param,CommandType commandType)
        {
            using (SqlConnection db = new SqlConnection(_dbConnectionString))
            {
                var res = await db.QueryFirstAsync<T>(prodName,param,commandType:commandType);
                return res;
            }
        }
    }
}
