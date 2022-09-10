using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace MyAlgorithm
{
    public class Test
    {

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count>0)
            {
                var curr = queue.Dequeue();
                var temp = curr.left;
                curr.left = curr.right;
                curr.right = temp;
                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }
            return root;
        }


    }

}
