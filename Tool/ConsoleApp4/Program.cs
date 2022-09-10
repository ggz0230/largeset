using NewLife.Caching;
using NewLife.Log;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static List<string> list = new List<string>();
        static void Main(string[] args)
        {

            List<string> ls = new List<string>();
            ls.Add("a");
            ls.Add("b");
            ls.Add("c");
            ls.Add("ggg");
            ls.Add("ggg");

            //ls = ls.Distinct().ToList();
            Console.WriteLine(ls.Count);

        }

        static async Task Show3()
        {
            using var db = new FullRedis("172.16.2.196:6379", "2011.paxsz", 0);
            db.Log = XTrace.Log;
            string key = "UserToken";
            string res = db.GetDictionary<string>(key)["5846"];
            Console.WriteLine(res);
            //db.GetDictionary<string>(key).Add("99988", "ssss");
            //db.GetDictionary<string>(key).Remove("5846");
        }

        static async Task Show2()
        {
            
            string conn = "172.16.2.196,password=2011.paxsz,defaultDatabase=0,poolsize=5,preheat=false,idleTimeout=5000,syncTimeout=5000,tryit=2";
            using CSRedis.CSRedisClient db = new CSRedis.CSRedisClient(conn);
            RedisHelper.Initialization(db);

            string key = "UserToken";
            var res = await db.HGetAsync(key, "5846");
            Console.WriteLine(res);
            
            //CSRedis.CSRedisClient db = new CSRedis.CSRedisClient(conn);
            //db.Dispose();
            //db.HSet(key, "www", "ffff");
            //db.Set("xxx", "ddd");
            //var ll = db.Del("xxx");
        }

        //static async Task ShowAsync()
        //{
        //    //var dd = RedisClien
        //    IRedisClientAsync db = new RedisClient("172.16.2.140", 6379);
        //    db.ConnectTimeout = 1000;

        //    string key = "UserToken";
        //    //db.Set<string>("sss", "ddd");
        //    //await db.SetEntryInHashAsync(key, "xxx", "xxddd");
        //    //await db.RemoveEntryFromHashAsync(key, "xxx");
        //    var list = await db.GetAllEntriesFromHashAsync(key);
        //    var rr = await db.GetValueFromHashAsync(key, "5846");
        //    Console.WriteLine(rr);
        //}
    }
}
