using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace MySortAlgorithm
{

    /// <summary>
    /// 242. 有效的字母异位词 
    /// https://leetcode-cn.com/problems/valid-anagram
    /// https://leetcode.com/problems/valid-anagram
    /// </summary>
    public class A242_ValidAnagram
    {
        /// <summary>
        /// 排序
        /// 时间复杂度：O(nlogn)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(String s, String t)
        {
            if (s.Length != t.Length) return false;
            char[] s1 = s.ToCharArray();
            char[] s2 = t.ToCharArray();
            Array.Sort(s1);
            Array.Sort(s2);
            return Enumerable.SequenceEqual(s1, s2);
        }



        /// <summary>
        /// 哈希 类似于计数排序
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram2(String s, String t)
        {
            if (s.Length != t.Length) return false;
            int[] arr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
                arr[t[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++)
            {
                if (arr[i] != 0) return false;
            }
            return true;
        }


    }
}
