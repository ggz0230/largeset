using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{

    public static class ConnectionStringMapper
    {
        //存放字符串主从关系
        private static readonly IDictionary<string, string[]> _mapper = new Dictionary<string, string[]>();
        private static readonly Random _random = new Random();

        static ConnectionStringMapper()
        {
            //添加数关系映射
            _mapper.Add(ConnectionStringConsts.MasterConnectionString, new[] { ConnectionStringConsts.SlaveConnectionString });
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="masterConnectionStr">主库连接字符串</param>
        /// <param name="useMaster">是否选择读主库</param>
        /// <returns></returns>
        public static string GetConnectionString(string masterConnectionStr, bool useMaster)
        {
            //是否走主库
            if (useMaster)
            {
                return masterConnectionStr;
            }

            if (!_mapper.Keys.Contains(masterConnectionStr))
            {
                throw new KeyNotFoundException("不存在的连接字符串");
            }

            //根据主库获取从库连接字符串
            string[] slaveStrs = _mapper[masterConnectionStr];
            if (slaveStrs.Length == 1)
            {
                return slaveStrs[0];
            }
            return slaveStrs[_random.Next(0, slaveStrs.Length - 1)];
        }
    }


}
