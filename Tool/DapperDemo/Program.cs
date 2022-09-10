using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "select id,name from Person where id=@id";
            var person =  DapperHelper.QueryAsync<dynamic>(sql, new { id = 1 }).Result.ToList();


        }
    }
}
