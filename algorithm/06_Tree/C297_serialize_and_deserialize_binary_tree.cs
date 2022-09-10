using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Tree
{
    /// <summary>
    /// 297. 二叉树的序列化与反序列化
    /// https://leetcode-cn.com/problems/serialize-and-deserialize-binary-tree/
    /// </summary>
    public class C297_serialize_and_deserialize_binary_tree
    {

    }

    /// <summary>
    /// dfs 递归
    /// </summary>
    public class Codec1
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
            { // 遇到null节点，“翻译”成X
                return "X,";
            }
            string leftSerialized = serialize(root.left);   // 左子树的序列化的字符串
            string rightSerialized = serialize(root.right); // 右子树的序列化的字符串
            return root.val + "," + leftSerialized + rightSerialized; // 按 根|左|右 顺序拼接
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(String data)
        {
            string[] temp = data.Split(",");
            Queue<string> dp = new Queue<string>(temp);
            return buildTree(dp);
        }

        private TreeNode buildTree(Queue<string> dq)
        {
            string s = dq.Dequeue(); //返回当前结点
            if (s.Equals("X")) return null;
            TreeNode node = new TreeNode(int.Parse(s))
            {
                left = buildTree(dq), //构建左子树
                right = buildTree(dq) //构建右子树
            };
            return node;
        }
    }

    /// <summary>
    /// bfs 
    /// </summary>
    public class Codec2
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            StringBuilder sb = new StringBuilder();
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null) sb.Append("X,");
                else
                {
                    sb.Append(node.val);
                    sb.Append(",");
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            return sb.ToString().TrimEnd(',');
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == null) return null;
            string[] arr = data.Split(',');
            if (arr == null || arr[0] == "X") return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(Convert.ToInt32(arr[0]));
            queue.Enqueue(root);
            int index = 0;
            while (index < arr.Length - 1)
            {
                TreeNode node = queue.Dequeue();
                string left = arr[++index];
                if (left != "X")
                {
                    TreeNode leftNode = new TreeNode(Convert.ToInt32(left));
                    node.left = leftNode;
                    queue.Enqueue(leftNode);
                }
                string right = arr[++index];
                if (right != "X")
                {
                    TreeNode rightNode = new TreeNode(Convert.ToInt32(right));
                    node.right = rightNode;
                    queue.Enqueue(rightNode);
                }
            }
            return root;
        }
    }

}
