using System;
using System.Collections.Generic;

namespace _06_Tree
{
    class Program
    {
        static void Main(string[] args)
        {


        }
    }


    /// <summary>
    /// 二叉树  Definition for a binary tree node.
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    /// <summary>
    /// n叉树  Definition for a Node.
    /// </summary>
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }


}
