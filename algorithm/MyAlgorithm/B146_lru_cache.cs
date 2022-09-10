using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 146. LRU缓存机制
    /// 最近使用原则
    /// https://leetcode-cn.com/problems/lru-cache
    /// </summary>
    public class B146_lru_cache { }

    /// <summary>
    /// 哈希(查找快)+链表(增删改快) 时间复杂度O(1)
    /// </summary>
    public class LRUCache
    {
        private Dictionary<int, LinkedListNode<int>> _hashes;
        private LinkedList<int> _list;
        private readonly int _capacity;

        public LRUCache(int capacity)
        {
            _hashes = new Dictionary<int, LinkedListNode<int>>(capacity);
            _list = new LinkedList<int>();
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_hashes.ContainsKey(key)) return -1;
            LinkedListNode<int> node = _hashes[key];
            if (node.List == null)
            {
                _hashes.Remove(key);
                return -1;
            }
            _list.Remove(node);
            _list.AddFirst(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (_hashes.ContainsKey(key))
            {
                LinkedListNode<int> node = _hashes[key];
                if (node.List != null)
                {
                    node.Value = value;
                    _list.Remove(node);
                    _list.AddFirst(node);
                    return;
                }
                _hashes.Remove(key);
            }
            if (_list.Count == _capacity) _list.RemoveLast();
            LinkedListNode<int> newNode = _list.AddFirst(value);
            _hashes.Add(key, newNode);
        }
    }

}
