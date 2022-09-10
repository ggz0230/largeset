using System;
using System.Collections.Generic;
using System.Text;

namespace _02_stack_quque
{
    /// <summary>
    /// 20. 有效的括号
    /// https://leetcode-cn.com/problems/valid-parentheses
    /// https://leetcode.com/problems/valid-parentheses
    /// </summary>
    public class A20_ValidParentheses
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            Stack<char> st = new Stack<char>();
            foreach (char item in s)
            {
                if (item == '(') { st.Push(')'); continue; }
                if (item == '[') { st.Push(']'); continue; }
                if (item == '{') { st.Push('}'); continue; }
                if (st.Count == 0 || st.Pop() != item)
                {
                    return false;
                }
            }
            return st.Count == 0;
        }



    }
}
