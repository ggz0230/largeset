using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Tree
{
    /// <summary>
    /// 104. 二叉树的最大深度
    /// https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/
    /// </summary>
    public class A104_maximum_depth_of_binary_tree
    {
        /// <summary>
        /// 递归  深度优先
        /// 时间复杂度O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int left = MaxDepth(root.left);
            int right = MaxDepth(root.right);
            return Math.Max(left, right) + 1;
        }

        /// <summary>
        /// 队列 广度优先 层次遍历思想 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth2(TreeNode root)
        {
            if (root == null) return 0;
            //BFS的层次遍历思想，记录二叉树的层数，
            //遍历完，层数即为最大深度
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int maxDepth = 0;
            while (queue.Count > 0)
            {
                maxDepth++;
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            return maxDepth;
        }

    }
}
