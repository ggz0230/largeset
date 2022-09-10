using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 100; i++)
            {
                Task.Run(() =>
                {
                    Show3();
                });

            }

            Console.ReadLine();
        }

        static void Show3()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("172.16.2.196,Password=2011.paxsz,SyncTimeout=3000,abortConnect=false");
            IDatabase db = redis.GetDatabase(0);
            string rekey = "UserToken";
            var rev = db.HashGet(rekey, 5846);
            Console.WriteLine(rev.ToString());

            //for (int i = 1; i < 10000; i++)
            //{
            //    db.HashSet(rekey, "zsm" + i, rev.ToString());
            //}
        }

        static void Show2()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            IDatabase db = redis.GetDatabase(0);
            for (int i = 1; i < 100000; i++)
            {
                db.HashSet("myset", "myfield" + i, JsonConvert.SerializeObject(new OnlineModel() { Name = "admin", LastTime = DateTime.Now, LastIp = "127.0.0.1", Id = i }));
            }
        }
        static void Show()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            int databaseNumber = 0;
            IDatabase database = redis.GetDatabase(databaseNumber);

            string key = "OnlineUsers";
            database.HashSet(key, "172.16.116.171_5846", JsonConvert.SerializeObject(new OnlineModel() { Name = "cang", LastTime = DateTime.Now }));
            database.HashSet(key, "172.16.116.172_1234", JsonConvert.SerializeObject(new OnlineModel() { Name = "shan", LastTime = DateTime.Now }));
            database.HashSet(key, "172.16.116.174_369", JsonConvert.SerializeObject(new OnlineModel() { Name = "yun" }));
            var list = database.HashGetAll(key);
            foreach (var item in list)
            {
                var mm = JsonConvert.DeserializeObject<OnlineModel>(item.Value);
                if (mm.Name == "cang")
                {
                    database.HashDelete(key, item.Key);
                }
            }
        }
    }



    public class OnlineModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 最近一次访问时间
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 最近一次访问的ip地址
        /// </summary>
        public string LastIp { get; set; }

    }
}
