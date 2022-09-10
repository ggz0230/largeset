using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 102. 二叉树的层序遍历    深度优先和广度优先的模板代码
    /// https://leetcode-cn.com/problems/binary-tree-level-order-traversal
    ///
    /// 深度优先 递归 栈
    /// </summary>
    public class B102_binary_tree_level_order_traversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> allResults = new List<IList<int>>();
            if (root == null)
            {
                return allResults;
            }
            dfs(root, 0, allResults);
            return allResults;
        }

        private void dfs(TreeNode root, int level, IList<IList<int>> results)
        {
            if (results.Count == level)
            {
                results.Add(new List<int>());
            }
            results[level].Add(root.val);
            if (root.left != null)
            {
                dfs(root.left, level + 1, results);
            }
            if (root.right != null)
            {
                dfs(root.right, level + 1, results);
            }
        }
    }

    /// <summary>
    /// 广度优先 队列
    /// </summary>
    public class B102_binary_tree_level_order_traversal2
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> allResults = new List<IList<int>>();
            if (root == null)
            {
                return allResults;
            }
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                int size = nodes.Count;
                List<int> results = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = nodes.Dequeue();
                    results.Add(node.val);
                    if (node.left != null)
                    {
                        nodes.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        nodes.Enqueue(node.right);
                    }
                }
                allResults.Add(results);
            }
            return allResults;
        }

    }

}
