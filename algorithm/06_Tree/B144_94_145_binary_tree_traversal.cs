using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_Tree
{
    /* 
    144. 二叉树的前序遍历 中左右  https://leetcode-cn.com/problems/binary-tree-preorder-traversal 
     94. 二叉树的中序遍历 左中右  https://leetcode-cn.com/problems/binary-tree-inorder-traversal
    145. 二叉树的后序遍历 左右中  https://leetcode-cn.com/problems/binary-tree-postorder-traversal
    */

    /// <summary>
    /// 递归 最为直观易懂，但考虑到效率，我们通常不推荐使用递归。
    /// </summary>
    public class B144_94_145_binary_tree_traversal1
    {
        /// <summary>
        /// 144. 二叉树的前序遍历（中左右）   https://leetcode-cn.com/problems/binary-tree-preorder-traversal
        /// 时间复杂度:O(n)
        /// 空间复杂度:O(h)，h是树的高度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            dfs(root);
            return res;
            void dfs(TreeNode root)
            {
                if (root == null) return;
                res.Add(root.val);
                dfs(root.left);
                dfs(root.right);
            }
        }

        /// <summary>
        /// 94. 二叉树的中序遍历（左中右）   https://leetcode-cn.com/problems/binary-tree-inorder-traversal
        /// 时间复杂度:O(n)
        /// 空间复杂度:O(h)，h是树的高度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> InorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            dfs(root);
            return res;

            void dfs(TreeNode root)
            {
                if (root == null) return;
                dfs(root.left);
                res.Add(root.val);
                dfs(root.right);
            }
        }


        /// <summary>
        /// 145. 二叉树的后序遍历（左右中）   https://leetcode-cn.com/problems/binary-tree-postorder-traversal
        /// 时间复杂度:O(n)
        /// 空间复杂度:O(h)，h是树的高度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> PostorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            dfs(root);
            return res;
            void dfs(TreeNode root)
            {
                if (root == null) return;
                dfs(root.left);
                dfs(root.right);
                res.Add(root.val);
            }
        }

    }


    /// <summary>
    /// 迭代   时间复杂度和空间复杂度:O(n)
    /// 本质上是在模拟递归，因为在递归的过程中使用了系统栈，所以在迭代的解法中常用Stack来模拟系统栈。
    /// </summary>
    public class B144_94_145_binary_tree_traversal2
    {
        /// <summary>
        /// 144. 二叉树的前序遍历（中左右）   https://leetcode-cn.com/problems/binary-tree-preorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            //简洁写法
            //List<int> res = new List<int>();
            //if (root == null) return res;
            //Stack<TreeNode> stack = new Stack<TreeNode>();
            //var curr = root;
            //stack.Push(curr);
            //while (stack.Count > 0)
            //{
            //    curr = stack.Pop();
            //    res.Add(curr.val);
            //    if (curr.right != null) stack.Push(curr.right);
            //    if (curr.left != null) stack.Push(curr.left);
            //}
            //return res;

            //和中序统一写法
            List<int> res = new List<int>();
            if (root == null) return res;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var curr = root;
            while (stack.Count > 0 || curr != null)
            {
                while (curr != null)
                {
                    res.Add(curr.val);
                    stack.Push(curr);
                    curr = curr.left;
                }
                var temp = stack.Pop();
                curr = temp.right;
            }
            return res;
        }

        /// <summary>
        /// 94. 二叉树的中序遍历（左中右）   https://leetcode-cn.com/problems/binary-tree-inorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> InorderTraversal(TreeNode root)
        {
            //和前序统一写法
            List<int> res = new List<int>();
            if (root == null) return res;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var curr = root;
            while (stack.Count > 0 || curr != null)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                var temp = stack.Pop();
                res.Add(temp.val);
                curr = temp.right;
            }
            return res;
        }


        /// <summary>
        /// 145. 二叉树的后序遍历（左右中）   https://leetcode-cn.com/problems/binary-tree-postorder-traversal
        /// 前序遍历（中左右）   -》  后序遍历（左右中）
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            //左右中 反过来 反过来输出
            List<int> res = new List<int>();
            if (root == null) return res;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var curr = root;
            while (stack.Count > 0 || curr != null)
            {
                while (curr != null)
                {
                    res.Insert(0, curr.val);
                    stack.Push(curr);
                    curr = curr.right;
                }
                var temp = stack.Pop();
                curr = temp.left;
            }
            return res;
        }

        /// <summary>
        /// 145. 二叉树的后序遍历（左右中）   https://leetcode-cn.com/problems/binary-tree-postorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> PostorderTraversal2(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;
            TreeNode cur = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode peek = stack.Peek();
                if (peek.left != null && peek.left != cur && peek.right != cur)
                {
                    stack.Push(peek.left);
                }
                else if (peek.right != null && peek.right != cur)
                {
                    stack.Push(peek.right);
                }
                else
                {
                    res.Add(stack.Pop().val);
                    cur = peek;
                }
            }
            return res;
        }

    }


    /// <summary>
    /// 标记法  统一写法
    /// </summary>
    public class B144_94_145_binary_tree_traversal3
    {
        /// <summary>
        /// 144. 二叉树的前序遍历（中左右）   https://leetcode-cn.com/problems/binary-tree-preorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal3(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;
            Stack<TreeNode> stack = new Stack<TreeNode>();   //调用栈
            stack.Push(root);    //先将根结点入栈
            while (stack.Count > 0)
            {
                TreeNode t = stack.Pop();
                if (t != null)
                {
                    if (t.right != null) stack.Push(t.right);
                    if (t.left != null) stack.Push(t.left);
                    stack.Push(t);   //完全模拟递归，真的是秒杀全场
                    stack.Push(null);    //！完美
                }
                else
                {
                    res.Add(stack.Pop().val);
                }
            }
            return res;
        }


        /// <summary>
        /// 94. 二叉树的中序遍历（左中右）   https://leetcode-cn.com/problems/binary-tree-inorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> InorderTraversal3(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;
            Stack<TreeNode> stack = new Stack<TreeNode>();   //调用栈
            stack.Push(root);    //先将根结点入栈
            while (stack.Count > 0)
            {
                TreeNode t = stack.Pop();
                if (t != null)
                {
                    if (t.right != null) stack.Push(t.right);
                    stack.Push(t);   //完全模拟递归，真的是秒杀全场
                    stack.Push(null);    //！完美
                    if (t.left != null) stack.Push(t.left);
                }
                else
                {
                    res.Add(stack.Pop().val);
                }
            }
            return res;
        }

        /// <summary>
        /// 145. 二叉树的后序遍历（左右中）   https://leetcode-cn.com/problems/binary-tree-postorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> PostorderTraversal3(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;
            Stack<TreeNode> stack = new Stack<TreeNode>();   //调用栈
            stack.Push(root);    //先将根结点入栈
            while (stack.Count > 0)
            {
                TreeNode t = stack.Pop();
                if (t != null)
                {
                    stack.Push(t);   //完全模拟递归，真的是秒杀全场
                    stack.Push(null);    //！完美
                    if (t.right != null) stack.Push(t.right);
                    if (t.left != null) stack.Push(t.left);
                }
                else
                {
                    res.Add(stack.Pop().val);
                }
            }
            return res;
        }
    }


}
