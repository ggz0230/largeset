using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    public class ConnectionStringConsts
    {
        /// <summary>
        /// 主库连接字符串
        /// </summary>
        public static readonly string MasterConnectionString = "server=db.master.com;Database=crm_db;UID=root;PWD=1";

        /// <summary>
        /// 从库连接字符串
        /// </summary>
        public static readonly string SlaveConnectionString = "server=db.slave.com;Database=crm_db;UID=root;PWD=1";
    }

}
