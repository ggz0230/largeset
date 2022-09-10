using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{

    /// <summary>
    /// 91. 解码方法 (中等)
    /// https://leetcode-cn.com/problems/decode-ways
    /// 动态规划
    /// </summary>
    public class B91_decode_ways
    {
        /// <summary>
        /// 情况比较多且复杂 暂时没吃透
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(String s)
        {
            if (s[0] == '0') return 0;//0开头 返回0
            int pre = 1, curr = 1;//dp[-1] = dp[0] = 1
            for (int i = 1; i < s.Length; i++)
            {
                int tmp = curr;
                if (s[i] == '0')
                {
                    //出现0的情况 只有组合成10 20 才有值 否则返回0
                    if (s[i - 1] == '1' || s[i - 1] == '2')
                    {
                        curr = pre;
                    }
                    else
                    {
                        return 0;// 0+非1/2 （例如：03 04 05 06 07 08 09） 返回0
                    }
                }
                else if (s[i - 1] == '1' || (s[i - 1] == '2' && s[i] >= '1' && s[i] <= '6'))
                {
                    //当前和前一个组合在1-26之间
                    curr = curr + pre;
                }
                pre = tmp;
            }
            return curr;
        }

        public int NumDecodings2(string s)
        {
            if (s[0] == '0') return 0;
            int pre = 1, curr = 1;//dp[-1] = dp[0] = 1
            for (int i = 1; i < s.Length; i++)
            {
                int tmp = curr;
                if (s[i] == '0')
                    if (s[i - 1] == '1' || s[i - 1] == '2') curr = pre;
                    else return 0;
                else if (s[i - 1] == '1' || (s[i - 1] == '2' && s[i] >= '1' && s[i] <= '6'))
                    curr = curr + pre;
                pre = tmp;
            }
            return curr;

        }


        //public int NumDecodings3(string s)
        //{
        //    if (s[0]=='0')
        //    {
        //        return 0;
        //    }
        //    int[] dp = new int[s.Length];
        //    dp[0] = 1;
        //    dp[1] = 
        //    for (int i = 0; i < s.Length; i++)
        //    {

        //    }
        //}
    }
}
