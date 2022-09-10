using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Tree
{
    /*
    105. 从前序与中序遍历序列构造二叉树
    https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
    */

    /// <summary>
    /// 递归
    /// 指针多 负责 难搞
    /// 时间复杂度 O(n^2)
    /// 空间复杂度 O(n)
    /// </summary>
    public class B105_1
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            int preLen = preorder.Length;
            int inLen = inorder.Length;
            if (preLen != inLen)
            {
                return null;
            }
            return buildTree(preorder, 0, preLen - 1, inorder, 0, inLen - 1);
        }


        /**
         * 使用数组 preorder 在索引区间 [preLeft, preRight] 中的所有元素
         * 和数组 inorder 在索引区间 [inLeft, inRight] 中的所有元素构造二叉树
         *
         * @param preorder 二叉树前序遍历结果
         * @param preLeft  二叉树前序遍历结果的左边界
         * @param preRight 二叉树前序遍历结果的右边界
         * @param inorder  二叉树后序遍历结果
         * @param inLeft   二叉树后序遍历结果的左边界
         * @param inRight  二叉树后序遍历结果的右边界
         * @return 二叉树的根结点
         */
        private TreeNode buildTree(int[] preorder, int preLeft, int preRight,
                                   int[] inorder, int inLeft, int inRight)
        {
            // 因为是递归调用的方法，按照国际惯例，先写递归终止条件
            if (preLeft > preRight || inLeft > inRight)
            {
                return null;
            }
            // 先序遍历的起点元素很重要
            int pivot = preorder[preLeft];
            TreeNode root = new TreeNode(pivot);
            int pivotIndex = inLeft;
            // 严格上说还要做数组下标是否越界的判断 pivotIndex < inRight
            while (inorder[pivotIndex] != pivot)
            {
                pivotIndex++;
            }
            root.left = buildTree(preorder, preLeft + 1, pivotIndex - inLeft + preLeft,
                    inorder, inLeft, pivotIndex - 1);
            root.right = buildTree(preorder, pivotIndex - inLeft + preLeft + 1, preRight,
                    inorder, pivotIndex + 1, inRight);
            return root;
        }



    }

    /// <summary>
    /// 递归+哈希 优化了时间复杂度
    /// 指针多 负责 难搞
    /// 时间复杂度 O(n)
    /// 空间复杂度 O(n)
    /// </summary>
    public class B105_2
    {
        private int[] preorder;
        private Dictionary<int, int> hash;

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            int preLen = preorder.Length;
            int inLen = inorder.Length;
            if (preLen != inLen)
            {
                return null;
            }
            this.preorder = preorder;
            this.hash = new Dictionary<int, int>();
            for (int i = 0; i < inLen; i++)
            {
                hash.Add(inorder[i], i);
            }

            return buildTree(0, preLen - 1, 0, inLen - 1);
        }

        private TreeNode buildTree(int preLeft, int preRight, int inLeft, int inRight)
        {
            // 因为是递归调用的方法，按照国际惯例，先写递归终止条件
            if (preLeft > preRight || inLeft > inRight)
            {
                return null;
            }
            // 先序遍历的起点元素很重要
            int pivot = preorder[preLeft];
            TreeNode root = new TreeNode(pivot);
            int pivotIndex = hash[pivot];
            root.left = buildTree(preLeft + 1, pivotIndex - inLeft + preLeft,
                    inLeft, pivotIndex - 1);
            root.right = buildTree(pivotIndex - inLeft + preLeft + 1, preRight,
                    pivotIndex + 1, inRight);
            return root;
        }

    }

    /// <summary>
    /// 栈
    /// </summary>
    public class B105_3
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0)
            {
                return null;
            }
            TreeNode root = new TreeNode(preorder[0]);
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            int inorderIndex = 0;
            for (int i = 1; i < preorder.Length; i++)
            {
                int preorderVal = preorder[i];
                TreeNode node = stack.Peek();
                if (node.val != inorder[inorderIndex])
                {
                    node.left = new TreeNode(preorderVal);
                    stack.Push(node.left);
                }
                else
                {
                    while (stack.Count > 0 && stack.Peek().val == inorder[inorderIndex])
                    {
                        node = stack.Pop();
                        inorderIndex++;
                    }
                    node.right = new TreeNode(preorderVal);
                    stack.Push(node.right);
                }
            }
            return root;
        }

    }

}
