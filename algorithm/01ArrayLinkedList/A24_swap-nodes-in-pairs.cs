using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 24. 两两交换链表中的节点
    /// https://leetcode-cn.com/problems/swap-nodes-in-pairs/
    /// </summary>
    public class A24_swap_nodes_in_pairs
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            //递归的终止条件
            if (head == null || head.next == null)
            {
                return head;
            }
            //假设链表是 1->2->3->4
            //这句就先保存节点2
            ListNode tmp = head.next;
            //继续递归，处理节点3->4
            //当递归结束返回后，就变成了4->3
            //于是head节点就指向了4，变成1->4->3
            head.next = SwapPairs(tmp.next);
            //将2节点指向1
            tmp.next = head;
            return tmp;
        }

        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs2(ListNode head)
        {
            //增加一个特殊节点方便处理
            ListNode p = new ListNode(-1)
            {
                next = head
            };
            //创建a，b两个指针，这里还需要一个tmp指针
            ListNode a = p;
            ListNode b = p;
            ListNode tmp = p;
            while (b != null && b.next != null && b.next.next != null)
            {
                //a前进一位，b前进两位
                a = a.next;
                b = b.next.next;
                //这步很关键，tmp指针用来处理边界条件的
                //假设链表是1->2->3->4，a指向1，b指向2
                //改变a和b的指向，于是就变成2->1，但是1指向谁呢？
                //1是不能指向2的next，1应该指向4，而循环迭代的时候一次处理2个节点
                //1和2的关系弄清楚了，3和4的关系也能弄清楚，但需要一个指针来处理
                //2->1，4->3的关系，tmp指针就是干这个用的
                tmp.next = b;
                a.next = b.next;
                b.next = a;
                //现在链表就变成2->1->3->4
                //tmp和b都指向1节点，等下次迭代的时候
                //a就变成3，b就变成4，然后tmp就指向b，也就是1指向4
                tmp = a;
                b = a;
            }
            return p.next;
        }


        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs3(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            //用stack保存每次迭代的两个节点
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode p = new ListNode(-1);
            ListNode cur = head;
            //head指向新的p节点，函数结束时返回head.next即可
            head = p;
            while (cur != null && cur.next != null)
            {
                //将两个节点放入stack中
                stack.Push(cur);
                stack.Push(cur.next);
                //当前节点往前走两步
                cur = cur.next.next;
                //从stack中弹出两个节点，然后用p节点指向新弹出的两个节点
                p.next = stack.Pop();
                p = p.next;
                p.next = stack.Pop();
                p = p.next;
            }
            //注意边界条件，当链表长度是奇数时，cur就不为空
            if (cur != null)
            {
                p.next = cur;
            }
            else
            {
                p.next = null;
            }
            return head.next;
        }
    }
}
