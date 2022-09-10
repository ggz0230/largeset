using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_hash_map
{
    /// <summary>
    /// 49. 字母异位词分组
    /// https://leetcode-cn.com/problems/group-anagrams
    /// https://leetcode.com/problems/group-anagrams
    /// </summary>
    public class B49_GroupAnagrams
    {

        /// <summary>
        /// 时间复杂度：O(n log n)
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {
            Dictionary<string, IList<string>> keyValues = new Dictionary<string, IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] arr = strs[i].ToCharArray();
                //排序
                Array.Sort(arr);
                //映射到 key
                string key = string.Concat(arr);
                //添加到对应的类中
                if (keyValues.ContainsKey(key))
                {
                    keyValues[key].Add(strs[i]);
                }
                else
                {
                    keyValues.Add(key, new List<string>() { strs[i] });
                }

            }
            return keyValues.Values.ToList();
        }

        /// <summary>
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// 首先初始化 key = "0#0#0#0#0#"，数字分别代表 abcde 出现的次数，# 用来分割。
        /// 这样的话，"abb" 就映射到了 "1#2#0#0#0"。
        /// "cdc" 就映射到了 "0#0#2#1#0"。
        /// "dcc" 就映射到了 "0#0#2#1#0"。
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            Dictionary<string, IList<string>> keyValues = new Dictionary<string, IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                int[] arr = new int[26];
                //记录每个字符的次数
                for (int j = 0; j < strs[i].Length; j++)
                {
                    arr[strs[i][j] - 'a']++;
                }
                //转成 0#2#2# 类似的形式
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < arr.Length; j++)
                {
                    sb.Append(arr[j] + '#');
                }
                string key = sb.ToString();
                if (keyValues.ContainsKey(key))
                {
                    keyValues[key].Add(strs[i]);
                }
                else
                {
                    keyValues.Add(key, new List<string>() { strs[i] });
                }
            }
            return keyValues.Values.ToList();
        }

        /// <summary>
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// 算术基本定理，又称为正整数的唯一分解定理，即：每个大于1的自然数，要么本身就是质数，要么可以写为2个以上的质数的积，而且这些质因子按大小排列之后，写法仅有一种方式。
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams3(string[] strs)
        {
            int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };
            Dictionary<long, IList<string>> dict = new Dictionary<long, IList<string>>();
            foreach (string str in strs)
            {
                long key = 1;
                foreach (char c in str)
                {
                    key *= primes[c - 'a'];
                }

                if (dict.ContainsKey(key))
                {
                    dict[key].Add(str);
                }
                else
                {
                    dict.Add(key, new List<string>() { str });
                }
            }
            return dict.Values.ToList();
        }

        public IList<IList<string>> GroupAnagrams4(string[] strs)
        {
            return strs
            .Select(s => (val: s, sorted: string.Concat(s.OrderBy(c => c))))
            .GroupBy(st => st.sorted, st => st.val)
            .Select(g => g.ToList() as IList<string>)
            .ToList();
        }

    }
}
