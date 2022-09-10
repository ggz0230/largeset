using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{

    /// <summary>
    /// 17. 电话号码的字母组合
    /// https://leetcode-cn.com/problems/letter-combinations-of-a-phone-number
    /// https://leetcode.com/problems/letter-combinations-of-a-phone-number
    /// </summary>
    public class B17_letter_combinations_of_a_phone_number
    {
        public IList<string> LetterCombinations(string digits)
        {
            //最终输出结果的list
            IList<string> res = new List<string>();

            //注意边界条件
            if (digits == null || digits.Length == 0) return res;

            //一个映射表，第二个位置是"abc“,第三个位置是"def"。。。
            //这里也可以用map，用数组可以更节省点内存
            string[] letter_map = { " ", "*", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            dfs(new StringBuilder(), 0);
            return res;

            //递归函数
            void dfs(StringBuilder letter, int index)
            {
                //递归的终止条件，注意这里的终止条件看上去跟动态演示图有些不同，主要是做了点优化
                //动态图中是每次截取字符串的一部分，"234"，变成"23"，再变成"3"，最后变成""，这样性能不佳
                //而用index记录每次遍历到字符串的位置，这样性能更好
                if (index == digits.Length)
                {
                    res.Add(letter.ToString());
                    return;
                }
                //获取index位置的字符，假设输入的字符是"234"
                //第一次递归时index为0所以c=2，第二次index为1所以c=3，第三次c=4
                //subString每次都会生成新的字符串，而index则是取当前的一个字符，所以效率更高一点
                char c = digits[index];
                //map_string的下表是从0开始一直到9， c-'0'就可以取到相对的数组下标位置
                //比如c=2时候，2-'0'，获取下标为2,letter_map[2]就是"abc"
                //int pos = Convert.ToInt32(c);
                int pos = c - '0';
                string map_string = letter_map[pos];
                //遍历字符串，比如第一次得到的是2，页就是遍历"abc"
                for (int i = 0; i < map_string.Length; i++)
                {
                    //调用下一层递归，用文字很难描述，请配合动态图理解
                    letter.Append(map_string[i]);
                    //如果是String类型做拼接效率会比较低
                    //iterStr(str, letter+map_string.charAt(i), index+1);
                    dfs(letter, index + 1);
                    letter.Remove(letter.Length - 1, 1);
                }
            }


        }

    }
}
