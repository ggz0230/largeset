//using ServiceStack.Redis;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ConsoleApp4
//{
//    /*
//     * 一个RedisHandle实例对应一个Redis服务端或者一组主从复制Redis服务端。
//     * 如果Redis需要做一致性哈希等集群，则要自己撰写算法来取相应的RedisHandle实例。
//     */

//    /// <summary>
//    /// Redis操作类
//    /// </summary>
//    public class RedisHandle
//    {
//        /// <summary>
//        /// Redis连接池管理实例
//        /// </summary>
//        public PooledRedisClientManager PooledClientManager { get; set; }

//        /* 如果你的需求需要经常切换Redis数据库，则可把Db当属性，这样每一个RedisHandle实例可以对应操作某Redis的某个数据库。此时，可在构造函数中增加int db参数。*/
//        ///// <summary>
//        ///// 一个Redis服务端默认有16个数据库，默认都是用第0个数据库。如果需要切换数据库，则传入db值(0~15)
//        ///// </summary>
//        //public int Db { get; set; }

//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        public RedisHandle()
//        {
//            #region 此代码为创建“连接池示例”，配置信息直接用静态类RedisClientConfig1承载，你也可以选择用配置文件承载
//            var config = new RedisClientManagerConfig
//            {
//                AutoStart = true,
//                MaxWritePoolSize = RedisClientConfig1.MaxWritePoolSize,
//                MaxReadPoolSize = RedisClientConfig1.MaxReadPoolSize,
//                DefaultDb = RedisClientConfig1.DefaultDb,
//            };
//            //如果你只用到一个Redis服务端，那么配置读写时就指定一样的连接字符串即可。
//            PooledClientManager = new PooledRedisClientManager()
//            {
//                ConnectTimeout = RedisClientConfig1.ConnectTimeout,
//                SocketSendTimeout = RedisClientConfig1.SendTimeout,
//                SocketReceiveTimeout = RedisClientConfig1.ReceiveTimeout,
//                IdleTimeOutSecs = RedisClientConfig1.IdleTimeOutSecs,
//                PoolTimeout = RedisClientConfig1.PoolTimeout
//            };
//            #endregion
//        }
//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        /// <param name="poolManager">连接池，外部传入自己创建的PooledRedisClientManager连接池对象，
//        /// 可以把其它RedisHandle实例的PooledClientManager传入，共用连接池</param>
//        public RedisHandle(PooledRedisClientManager poolManager)
//        {
//            PooledClientManager = poolManager;

//        }
//        /// <summary>
//        /// 获取Redis客户端连接对象，有连接池管理。
//        /// </summary>
//        /// <param name="isReadOnly">是否取只读连接。Get操作一般是读，Set操作一般是写</param>
//        /// <returns></returns>
//        public RedisClient GetRedisClient(bool isReadOnly = false)
//        {
//            RedisClient result;
//            if (!isReadOnly)
//            {
//                //RedisClientManager.GetCacheClient()会返回一个新实例，而且只提供一小部分方法，它的作用是帮你判断是否用写实例还是读实例
//                result = PooledClientManager.GetClient() as RedisClient;
//            }
//            else
//            {
//                //如果你读写是两个做了主从复制的Redis服务端，那么要考虑主从复制是否有延迟。有一些读操作是否是即时的，需要在写实例中获取。
//                result = PooledClientManager.GetReadOnlyClient() as RedisClient;
//            }
//            //如果你的需求需要经常切换Redis数据库，则下一句可以用。否则一般都只用默认0数据库，集群是没有数据库的概念。
//            //result.ChangeDb(Db);
//            return result;
//        }

//        public void SetValue(string key, string value, int expirySeconds = -1)
//        {
//            using (RedisClient redisClient = GetRedisClient())
//            {
//                //redisClient.SetEntry(key, value, expireIn);
//                if (expirySeconds == -1)
//                {
//                    redisClient.SetValue(key, value);
//                }
//                else
//                {
//                    redisClient.SetValue(key, value, new TimeSpan(0, 0, 0, expirySeconds));
//                }
//            }
//        }

//        public string GetValue(string key)
//        {
//            using (RedisClient redisClient = GetRedisClient(true))
//            {
//                var val = redisClient.GetValue(key);

//                return val;
//            }
//        }

//    }
//}