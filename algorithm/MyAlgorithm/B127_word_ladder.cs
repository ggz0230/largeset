using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 127. 单词接龙  暂时看不懂代码
    /// https://leetcode-cn.com/problems/word-ladder
    /// </summary>
    public class B127_word_ladder
    {
        /// <summary>
        /// 双端队列 
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord)) return 0;
            HashSet<string> wordSet = new HashSet<string>(wordList);
            HashSet<string> beginSet = new HashSet<string>() { beginWord };
            HashSet<string> endSet = new HashSet<string>() { endWord };

            int len = 1;
            HashSet<string> visited = new HashSet<string>();

            while (beginSet.Count > 0 && endSet.Count > 0)
            {
                if (beginSet.Count > endSet.Count)
                {
                    HashSet<string> set = beginSet;
                    beginSet = endSet;
                    endSet = set;
                }
                HashSet<string> temp = new HashSet<string>();
                foreach (string word in beginSet)
                {
                    char[] chs = word.ToCharArray();
                    for (int i = 0; i < chs.Length; i++)
                    {
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            char old = chs[i];
                            chs[i] = c;
                            string target = new string(chs);
                            if (endSet.Contains(target))
                            {
                                return len + 1;
                            }
                            if (!visited.Contains(target) && wordSet.Contains(target))
                            {
                                temp.Add(target);
                                visited.Add(target);
                            }
                            chs[i] = old;
                        }
                    }
                }
                beginSet = temp;
                len++;
            }
            return 0;
        }
    }
}
