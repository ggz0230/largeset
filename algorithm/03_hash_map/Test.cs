using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_hash_map
{
    public class Test
    {
        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {
            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();

            foreach (var item in strs)
            {
                var arr = item.ToCharArray();
                Array.Sort(arr);
                string key = string.Concat(arr);
                if (dic.ContainsKey(key))
                {
                    dic[key].Add(item);
                }
                else
                {
                    dic.Add(key, new List<string>() { item });
                }
            }
            return dic.Values.ToList();

        }


    }
}
