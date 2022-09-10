using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Tree
{
    /// <summary>
    /// 226. 翻转二叉树
    /// https://leetcode-cn.com/problems/invert-binary-tree
    /// </summary>
    public class A226_invert_binary_tree
    {
        /// <summary>
        /// 递归  深度优先
        /// 时间复杂度O(n)  空间复杂度O(h)  h是树的高度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree(TreeNode root)
        {
            //递归函数的终止条件，节点为空时返回
            if (root == null) return null;

            //下面三句是将当前节点的左右子树交换
            TreeNode tmp = root.right;
            root.right = root.left;
            root.left = tmp;
            //递归交换当前节点的 左子树
            InvertTree(root.left);
            //递归交换当前节点的 右子树
            InvertTree(root.right);
            //函数返回时就表示当前这个节点，以及它的左右子树
            //都已经交换完了
            return root;
        }

        /// <summary>
        /// 迭代 队列 广度优先
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree2(TreeNode root)
        {
            if (root == null) return null;

            //将二叉树中的节点逐层放入队列中，再迭代处理队列中的元素
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                //每次都从队列中拿一个节点，并交换这个节点的左右子树
                TreeNode tmp = queue.Dequeue();
                TreeNode left = tmp.left;
                tmp.left = tmp.right;
                tmp.right = left;
                //如果当前节点的左子树不为空，则放入队列等待后续处理
                if (tmp.left != null) queue.Enqueue(tmp.left);
                //如果当前节点的右子树不为空，则放入队列等待后续处理
                if (tmp.right != null) queue.Enqueue(tmp.right);
            }
            //返回处理完的根节点
            return root;
        }

    }
}
