using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Tree
{
    /// <summary>
    /// 111. 二叉树的最小深度
    /// https://leetcode-cn.com/problems/minimum-depth-of-binary-tree/
    /// </summary>
    public class A111_minimum_depth_of_binary_tree
    {
        /// <summary>
        /// 递归 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            int m1 = MinDepth(root.left);
            int m2 = MinDepth(root.right);
            //1.如果左孩子和右孩子有为空的情况，直接返回m1+m2+1
            //2.如果都不为空，返回较小深度+1
            return root.left == null || root.right == null ? m1 + m2 + 1 : Math.Min(m1, m2) + 1;
        }

        /// <summary>
        /// 广度优先 队列
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth2(TreeNode root)
        {
            if (root == null) return 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);//入队
            int level = 0;
            while (queue.Count > 0)
            {//队列不为空就继续循环
                level++;
                int levelCount = queue.Count;
                for (int j = 0; j < levelCount; j++)
                {
                    TreeNode node = queue.Dequeue();//出队
                    //如果当前node节点的左右子树都为空，直接返回level即可
                    if (node.left == null && node.right == null) return level;
                    //左右子节点，哪个不为空，哪个加入到队列中
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            return -1;
        }


    }
}
