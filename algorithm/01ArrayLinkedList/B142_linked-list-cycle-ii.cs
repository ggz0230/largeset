using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 142. 环形链表 II （中等）
    /// https://leetcode.com/problems/linked-list-cycle-ii
    /// </summary>
    public class B142_linked_list_cycle_ii
    {
        public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head, slow = head;
            while (true)
            {
                if (fast == null || fast.next == null) return null;
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow) break;
            }
            fast = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return fast;
        }


    }
}
