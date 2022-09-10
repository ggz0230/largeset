using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 208. 实现 Trie (前缀树)
    /// https://leetcode-cn.com/problems/implement-trie-prefix-tree/
    /// </summary>
    public class B208_implement_trie_prefix_tree
    {

    }

    class Trie
    {
        private bool IsEnd { get; set; }
        private Trie[] Nodes { get; } = new Trie[26];
        /** Initialize your data structure here. */
        public Trie()
        {

        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            Trie node = this;
            foreach (var a in word)
            {
                if (node.Nodes[a - 'a'] == null)
                    node.Nodes[a - 'a'] = new Trie();
                node = node.Nodes[a - 'a'];
            }
            node.IsEnd = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            Trie node = this;
            foreach (var a in word)
            {
                node = node.Nodes[a - 'a'];
                if (node == null)
                    return false;
            }
            return node.IsEnd;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            Trie node = this;
            foreach (var a in prefix)
            {
                node = node.Nodes[a - 'a'];
                if (node == null)
                    return false;
            }
            return true;
        }
    }

}
