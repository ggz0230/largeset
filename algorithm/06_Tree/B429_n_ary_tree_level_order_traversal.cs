using System.Collections.Generic;

namespace _06_Tree
{

    /// <summary>
    /// 429. N叉树的层序遍历
    /// https://leetcode-cn.com/problems/n-ary-tree-level-order-traversal
    /// https://leetcode.com/problems/n-ary-tree-level-order-traversal
    /// </summary>
    public class B429_n_ary_tree_level_order_traversal
    {
        /// <summary>
        /// 队列 广度优先搜索
        /// 时间复杂度：O(n)   n 指的是节点的数量
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                List<int> level = new List<int>();
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    Node node = queue.Dequeue();
                    level.Add(node.val);
                    foreach (var item in node.children)
                    {
                        queue.Enqueue(item);
                    }
                }
                result.Add(level);
            }
            return result;
        }

        /// <summary>
        /// 队列 简化的广度优先搜索
        /// 时间复杂度：O(n)   n 指的是节点的数量
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder2(Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            List<Node> previousLayer = new List<Node>() { root };

            while (previousLayer.Count > 0)
            {
                List<Node> currentLayer = new List<Node>();
                List<int> previousVals = new List<int>();
                foreach (var node in previousLayer)
                {
                    previousVals.Add(node.val);
                    currentLayer.AddRange(node.children);
                }
                result.Add(previousVals);
                previousLayer = currentLayer;
            }

            return result;
        }

        /// <summary>
        /// 递归 深度优先
        /// 时间复杂度：O(n)   n 指的是节点的数量
        /// 空间复杂度：正常情况 O(log n)O，最坏情况 O(n)。运行时在堆栈上的空间。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder3(Node root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root != null) traverseNode(root, 0);
            return res;

            void traverseNode(Node node, int level)
            {
                if (res.Count <= level)
                {
                    res.Add(new List<int>());
                }
                res[level].Add(node.val);
                foreach (var item in node.children)
                {
                    traverseNode(item, level + 1);
                }
            }

        }


    }
}
