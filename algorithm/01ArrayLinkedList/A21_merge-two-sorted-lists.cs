using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 21. 合并两个有序链表
    /// https://leetcode-cn.com/problems/merge-two-sorted-lists/
    /// </summary>
    public class A21_merge_two_sorted_lists
    {
        /// <summary>
        /// 递归 遇终止条件回溯
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }

            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }

    }
}
