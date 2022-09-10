using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStringAlgorithm
{
    /// <summary>
    /// 字符串基础题（简单）
    /// </summary>
    public class StringBase
    {

        #region 709. 转换成小写字母
        //https://leetcode-cn.com/problems/to-lower-case
        /// <summary>
        /// Ascii 解法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ToLowerCase(string str)
        {
            // 'A' 65       'Z' 90       'a' 97
            // 'a' - 'A' 32
            StringBuilder sb = new StringBuilder();
            foreach (var s in str)
            {
                sb.Append(s >= 'A' && s <= 'Z' ? (char)(s + 32) : s);
            }
            return sb.ToString();
        }
        #endregion

        #region 58. 最后一个单词的长度
        //https://leetcode.com/problems/length-of-last-word
        /// <summary>
        /// 最优解
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            //s = s.TrimEnd(' ');
            int end = s.Length - 1;
            while (end > 0 && s[end] == ' ') end--;  //除去最后为空格的字符串
            int res = 0;
            for (int i = end; i >= 0; i--)
            {
                if (s[i] == ' ') break;
                res++;
            }
            return res;
        }

        public int LengthOfLastWord2(string s)
        {
            string str = s.Trim();
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    count = 0;
                }
                else
                {
                    count = count + 1;
                }
            }
            return count;
        }
        public int LengthOfLastWord3(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            var TrimedS = s.Trim();
            var i = TrimedS.LastIndexOf(' ');
            return TrimedS.Length - i - 1;
        }

        public int LengthOfLastWord4(string s)
        {
            int end = s.Length - 1;
            while (end >= 0 && s[end] == ' ') end--;
            if (end < 0) return 0;
            int start = end;
            while (start >= 0 && s[start] != ' ') start--;
            return end - start;
        }
        #endregion

        #region 771. 宝石与石头
        //https://leetcode-cn.com/problems/jewels-and-stones
        /// <summary>
        /// 
        /// </summary>
        /// <param name="J"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int NumJewelsInStones(string J, string S)
        {
            HashSet<char> set = new HashSet<char>();
            foreach (var s in J)
            {
                set.Add(s);
            }
            int res = 0;
            foreach (var s in S)
            {
                if (set.Contains(s)) res++;
            }
            return res;
        }

        public int NumJewelsInStones2(string J, string S)
        {
            return (from j in J from s in S where j == s select s).Count();
        }

        public int NumJewelsInStones3(string J, string S)
        {
            return S.Count(stone => J.Contains(stone));
        }

        #endregion

        #region 387. 字符串中的第一个唯一字符
        // https://leetcode.com/problems/first-unique-character-in-a-string/
        /// <summary>
        /// 最优解
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s)
        {
            int[] arr = new int['z' + 1];//123
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i]]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (arr[s[i]] == 1) return i;
            }
            return -1;
        }

        public int FirstUniqChar2(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]] += 1;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (dict[s[i]] == 1) return i;
            }
            return -1;
        }
        #endregion

        #region 8. 字符串转换整数 (atoi) （中等）
        //https://leetcode.com/problems/string-to-integer-atoi
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int MyAtoi(string s)
        {
            int index = 0, sign = 1, total = 0;
            //1. 判断空字符串  empty string
            if (s.Length == 0) return 0;

            //2. 移除前面的空格 remove spaces
            while (s[index] == ' ' && index < s.Length - 1) index++;

            //3. 最开始的正负符号 handle signs
            switch (s[index])
            {
                case '+': index++; break;
                case '-': index++; sign = -1; break;
            }

            //4. 遍历 字符转数字 convert number and avoid overflow
            while (index < s.Length)//421
            {
                int digit = s[index] - '0';
                if (digit < 0 || digit > 9) break;

                if (int.MaxValue / 10 < total || int.MaxValue / 10 == total && int.MaxValue % 10 < digit)
                {
                    return sign == 1 ? int.MaxValue : int.MinValue;
                }
                total = 10 * total + digit;
                index++;
            }

            return total * sign;
        }

        #endregion

    }

}
