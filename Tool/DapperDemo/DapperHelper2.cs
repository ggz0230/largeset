using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperDemo
{

    public class DapperHelper2
    {
        private string _connStr;
        public DapperHelper2(string connStr)
        {
            _connStr = connStr;
        }

        public async Task QueryAsync(string sql)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                var invoices = await connection.QueryAsync<dynamic>(sql);
            }

        }
    }


}
