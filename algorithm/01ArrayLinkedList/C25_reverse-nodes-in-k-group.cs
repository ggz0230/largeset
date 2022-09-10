using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 25. K 个一组翻转链表 （困难） 递归的暂时没做好，太复杂了
    /// https://leetcode-cn.com/problems/reverse-nodes-in-k-group
    /// </summary>
    public class C25_reverse_nodes_in_k_group
    {
        /// <summary>
        /// 递归解法
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            //定义一个假的节点。
            ListNode dummy = new ListNode(0);
            //假节点的next指向head。
            // dummy->1->2->3->4->5
            dummy.next = head;
            //初始化pre和end都指向dummy。pre指每次要翻转的链表的头结点的上一个节点。end指每次要翻转的链表的尾节点
            ListNode pre = dummy;
            ListNode end = dummy;

            while (end.next != null)
            {
                //循环k次，找到需要翻转的链表的结尾,这里每次循环要判断end是否等于空,因为如果为空，end.next会报空指针异常。
                //dummy->1->2->3->4->5 若k为2，循环2次，end指向2
                for (int i = 0; i < k && end != null; i++)
                {
                    end = end.next;
                }
                //如果end==null，即需要翻转的链表的节点数小于k，不执行翻转。
                if (end == null)
                {
                    break;
                }
                //先记录下end.next,方便后面链接链表
                ListNode next = end.next;
                //然后断开链表
                end.next = null;
                //记录下要翻转链表的头节点
                ListNode start = pre.next;
                //翻转链表,pre.next指向翻转后的链表。1->2 变成2->1。 dummy->2->1
                pre.next = Reverse(start);
                //翻转后头节点变到最后。通过.next把断开的链表重新链接。
                start.next = next;
                //将pre换成下次要翻转的链表的头结点的上一个节点。即start
                pre = start;
                //翻转结束，将end置为下次要翻转的链表的头结点的上一个节点。即start
                end = start;
            }
            return dummy.next;
        }

        //链表翻转
        // 例子：   head： 1->2->3->4
        public ListNode Reverse(ListNode head)
        {
            //单链表为空或只有一个节点，直接返回原单链表
            if (head == null || head.next == null)
            {
                return head;
            }
            //前一个节点指针
            ListNode preNode = null;
            //当前节点指针
            ListNode curNode = head;
            //下一个节点指针
            ListNode nextNode = null;
            while (curNode != null)
            {
                nextNode = curNode.next;//nextNode 指向下一个节点,保存当前节点后面的链表。
                curNode.next = preNode;//将当前节点next域指向前一个节点   null<-1<-2<-3<-4
                preNode = curNode;//preNode 指针向后移动。preNode指向当前节点。
                curNode = nextNode;//curNode指针向后移动。下一个节点变成当前节点
            }
            return preNode;
        }


        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup2(ListNode head, int k)
        {
            Stack<ListNode> st = new Stack<ListNode>();
            ListNode dummy = new ListNode();
            ListNode p = dummy;
            while (true)
            {
                var temp = head;
                while (temp != null && st.Count < k)
                {
                    st.Push(temp);
                    temp = temp.next;
                }
                if (st.Count < k)
                {
                    p.next = head;
                    break;
                }
                while (st.Count > 0)
                {
                    p.next = st.Pop();
                    p = p.next;
                }
                head = temp;
            }
            return dummy.next;
        }

    }


    public class C25_reverse_nodes_in_k_group2
    {
        /// <summary>
        /// 递归  1 2 3 4 5 6 7   k=2
        /// </summary>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode cur = head;
            int count = 0;
            while (cur != null && count != k)
            {
                cur = cur.next;
                count++;
            }
            if (count == k)
            {
                cur = ReverseKGroup(cur, k);
                while (count != 0)
                {
                    count--;
                    ListNode tmp = head.next;
                    head.next = cur;
                    cur = head;
                    head = tmp;
                }
                head = cur;
            }
            return head;
        }
    }

}
