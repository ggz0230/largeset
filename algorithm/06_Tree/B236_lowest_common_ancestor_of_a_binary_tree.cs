using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Tree
{
    /// <summary>
    /// 236. 二叉树的最近公共祖先   有点难理解 递归精髓
    /// https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/
    /// </summary>
    public class B236_lowest_common_ancestor_of_a_binary_tree
    {
        /// <summary>
        /// 递归
        /// 因为是递归，使用函数后可认为左右子树已经算出结果，这句话要记住，道出了递归的精髓
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q) return root;
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            //if (left == null && right == null) return null; // 1.   3.4.步已经包含了1 所以注释掉
            if (left == null) return right; // 3.
            if (right == null) return left; // 4.
            return root; // 2. if(left != null and right != null)
        }

    }
}
