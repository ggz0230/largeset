using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    public static class DapperHelper
    {
        public static IDbConnection GetConnection(string connectionStr)
        {
            return new SqlConnection(connectionStr);
        }

        /// <summary>
        /// 执行查询相关操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="useMaster">是否去读主库</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, bool useMaster = false)
        {
            //根据实际情况选择需要读取数据库的字符串
            string connectionStr = ConnectionStringMapper.GetConnectionString(ConnectionStringConsts.MasterConnectionString, useMaster);
            using (var connection = GetConnection(connectionStr))
            {
                return await connection.QueryAsync<T>(sql, param);
            }
        }

        /// <summary>
        /// 执行查询相关操作
        /// </summary>
        /// <param name="connectionStr">连接字符串</param>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="useMaster">是否去读主库</param>
        /// <returns></returns>
        public static IEnumerable<T> Query<T>(string connectionStr, string sql, object param = null, bool useMaster = false)
        {
            //根据实际情况选择需要读取数据库的字符串
            connectionStr = ConnectionStringMapper.GetConnectionString(connectionStr, useMaster);
            using var connection = GetConnection(connectionStr);
            return connection.Query<T>(sql, param);
        }

        /// <summary>
        /// 执行事务相关操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static int Execute(string sql, object param = null)
        {
            return Execute(ConnectionStringConsts.MasterConnectionString, sql, param);
        }

        /// <summary>
        /// 执行事务相关操作
        /// </summary>
        /// <param name="connectionStr">连接字符串</param>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static int Execute(string connectionStr, string sql, object param = null)
        {
            using (var connection = GetConnection(connectionStr))
            {
                return connection.Execute(sql, param);
            }
        }

        /// <summary>
        /// 事务封装
        /// </summary>
        /// <param name="func">操作</param>
        /// <returns></returns>
        public static bool ExecuteTransaction(Func<IDbConnection, IDbTransaction, int> func)
        {
            return ExecuteTransaction(ConnectionStringConsts.MasterConnectionString, func);
        }

        /// <summary>
        /// 事务封装
        /// </summary>
        /// <param name="connectionStr">连接字符串</param>
        /// <param name="func">操作</param>
        /// <returns></returns>
        public static bool ExecuteTransaction(string connectionStr, Func<IDbConnection, IDbTransaction, int> func)
        {
            using (var conn = GetConnection(connectionStr))
            {
                IDbTransaction trans = conn.BeginTransaction();
                return func(conn, trans) > 0;
            }
        }

    }

}
