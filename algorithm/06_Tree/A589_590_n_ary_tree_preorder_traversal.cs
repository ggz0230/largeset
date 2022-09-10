using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Tree
{
    /*
    589. N叉树的前序遍历 根 左 右
    https://leetcode-cn.com/problems/n-ary-tree-preorder-traversal
     
    590. N叉树的后序遍历 左 右 根
    https://leetcode-cn.com/problems/n-ary-tree-postorder-traversal
    */

    /// <summary>
    /// 递归
    /// </summary>
    public class A589_590_n_ary_tree_preorder_traversal
    {
        /// <summary>
        /// 589. N叉树的前序遍历
        /// https://leetcode-cn.com/problems/n-ary-tree-preorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            IList<int> res = new List<int>();
            dfs(root);
            return res;

            void dfs(Node node)
            {
                if (node == null) return;
                res.Add(node.val);
                foreach (var item in node.children)
                {
                    dfs(item);
                }
            }
        }

        /// <summary>
        /// 590. N叉树的后序遍历
        /// https://leetcode-cn.com/problems/n-ary-tree-postorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder(Node root)
        {
            IList<int> res = new List<int>();
            dfs(root);
            return res;

            void dfs(Node node)
            {
                if (node == null) return;
                foreach (var item in node.children)
                {
                    dfs(item);
                }
                res.Add(node.val);
            }
        }

    }

    /// <summary>
    /// 迭代
    /// </summary>
    public class A589_590_n_ary_tree_preorder_traversal2
    {
        /// <summary>
        /// 589. N叉树的前序遍历（根-左-右）  
        /// https://leetcode-cn.com/problems/n-ary-tree-preorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            IList<int> res = new List<int>();
            if (root == null) return res;
            Stack<Node> st = new Stack<Node>();
            st.Push(root);
            while (st.Count > 0)
            {
                Node node = st.Pop();
                res.Add(node.val);
                for (int i = node.children.Count - 1; i >= 0; i--)
                {
                    st.Push(node.children[i]);
                }
            }
            return res;
        }

        /// <summary>
        /// 590. N叉树的后序遍历（左-右-根）
        /// https://leetcode-cn.com/problems/n-ary-tree-postorder-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder(Node root)
        {
            IList<int> res = new List<int>();
            if (root == null) return res;
            Stack<Node> st = new Stack<Node>();
            st.Push(root);
            while (st.Count > 0)
            {
                Node node = st.Pop();
                res.Insert(0, node.val);
                for (int i = 0; i < node.children.Count; i++)
                {
                    st.Push(node.children[i]);
                }
            }
            return res;
        }

    }

}
