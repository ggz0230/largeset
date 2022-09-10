using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 141. 环形链表
    /// https://leetcode-cn.com/problems/linked-list-cycle
    /// https://leetcode.com/problems/linked-list-cycle
    /// </summary>
    public class A141_LinkedListCycle
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle2(ListNode head)
        {
            ListNode fast = head, slow = head;
            while (true)
            {
                if (fast == null || fast.next == null) return false;
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow) return true;
            }
        }

        /// <summary>
        /// 暴力法  放哈希表里，有重复就是环形的
        /// 时间复杂度 O(n)
        /// 空间复杂度 O(n)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            HashSet<ListNode> nodes = new HashSet<ListNode>();
            while (head != null)
            {
                if (nodes.Contains(head))
                {
                    return true;
                }
                nodes.Add(head);
                head = head.next;
            }
            return false;
        }

    }

}
