using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 206. 反转链表
    /// https://leetcode-cn.com/problems/reverse-linked-list
    /// </summary>
    public class A206_reverse_linked_list
    {
        /// <summary>
        /// 双指针迭代法
        /// 时间复杂度 O(n) 
        /// 空间复杂度 O(1) 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList2(ListNode head)
        {
            //申请节点，pre和 cur，pre指向null
            ListNode pre = null;
            ListNode cur = head;
            ListNode tmp = null;
            while (cur != null)
            {
                //记录当前节点的下一个节点
                tmp = cur.next;
                // 逐个结点反转
                cur.next = pre;
                // 更新指针位置  pre和cur节点都前进一位
                pre = cur;
                cur = tmp;
            }
            // 返回反转后的头结点
            return pre;
        }

        /// <summary>
        /// 迭代法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            //递归终止条件是当前为空，或者下一个节点为空
            if (head == null || head.next == null)
            {
                return head;
            }
            //这里的cur就是最后一个节点
            ListNode cur = ReverseList(head.next);
            //这里请配合动画演示理解
            //如果链表是 1->2->3->4->5，那么此时的cur就是5
            //而head是4，head的下一个是5，下下一个是空
            //所以head.next.next 就是5->4
            head.next.next = head;
            //防止链表循环，需要将head.next设置为空
            head.next = null;
            //每层递归函数都返回cur，也就是最后一个节点
            return cur;
        }

    }
}
