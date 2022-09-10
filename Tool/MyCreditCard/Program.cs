using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreditCard
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = "Card.json";
            string text = File.ReadAllText(filePath);

            List<Card> list = JsonConvert.DeserializeObject<List<Card>>(text);
            Card zongCard = list.FirstOrDefault(q => q.Name == "总");

            zongCard.TotalQuota = 0;
            zongCard.SurplusQuota = 0;
            zongCard.UsedQuota = 0;
            foreach (var item in list.Where(q => q.Name != "总"))
            {
                //求已用额度
                item.UsedQuota = item.TotalQuota - item.SurplusQuota;
                zongCard.TotalQuota += item.TotalQuota;
                zongCard.SurplusQuota += item.SurplusQuota;
            }
            zongCard.UsedQuota = zongCard.TotalQuota - zongCard.SurplusQuota;

            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filePath, json, Encoding.UTF8);

            Console.WriteLine(json);
            Console.ReadKey();

        }
    }
}
