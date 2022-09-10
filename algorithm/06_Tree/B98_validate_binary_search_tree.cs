using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Tree
{
    /// <summary>
    /// 98. 验证二叉搜索树
    /// https://leetcode-cn.com/problems/validate-binary-search-tree/
    /// </summary>
    public class B98_validate_binary_search_tree
    {
        /// <summary>
        /// 中序遍历（左中右） 递归   右之前一定是左 所以当前节点小于等于前一个节点就是false
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>

        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            // 访问左子树
            if (!IsValidBST(root.left)) return false;
            // 访问当前节点：如果当前节点小于等于中序遍历的前一个节点，说明不满足BST，返回 false；否则继续遍历。
            if (root.val <= pre) return false;
            pre = root.val;
            // 访问右子树
            return IsValidBST(root.right);
        }
        long pre = long.MinValue;


        /// <summary>
        /// 中序遍历（左中右）  栈
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST2(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            int inorder = -int.MaxValue;

            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                // 如果中序遍历得到的节点的值小于等于前一个 inorder，说明不是二叉搜索树
                if (root.val <= inorder)
                {
                    return false;
                }
                inorder = root.val;
                root = root.right;
            }
            return true;
        }


    }
}
