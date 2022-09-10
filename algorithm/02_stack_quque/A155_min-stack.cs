using System;
using System.Collections.Generic;
using System.Text;

namespace _02_stack_quque
{
    /// <summary>
    /// 155. 最小栈
    /// https://leetcode-cn.com/problems/min-stack
    /// </summary>
    public class A155_min_stack
    {
    }

    public class MinStack1
    {
        private Stack<int> stack;
        private Stack<int> minStack;
        /** initialize your data structure here. */
        public MinStack1()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (minStack.Count == 0)
            {
                minStack.Push(x);
            }
            else if (x <= minStack.Peek())
            {
                minStack.Push(x);
            }
        }

        public void Pop()
        {
            int pop = stack.Pop();
            if (pop == minStack.Peek())
            {
                minStack.Pop();
            }
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }

    public class MinStack2
    {
        int min = int.MaxValue;
        Stack<int> stack = new Stack<int>();
        public void Push(int x)
        {
            //当前值更小
            if (x <= min)
            {
                //将之前的最小值保存
                stack.Push(min);
                //更新最小值
                min = x;
            }
            stack.Push(x);
        }

        public void Pop()
        {
            //如果弹出的值是最小值，那么将下一个元素更新为最小值
            if (stack.Pop() == min)
            {
                min = stack.Pop();
            }
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return min;
        }
    }

    public class MinStack3
    {
        long min;
        Stack<long> stack;

        public MinStack3()
        {
            stack = new Stack<long>();
        }

        public void Push(int x)
        {
            if (stack.Count == 0)
            {
                min = x;
                stack.Push(x - min);
            }
            else
            {
                stack.Push(x - min);
                if (x < min)
                {
                    min = x; // 更新最小值
                }

            }
        }

        public void Pop()
        {
            if (stack.Count == 0) return;

            long pop = stack.Pop();

            //弹出的是负值，要更新 min
            if (pop < 0)
            {
                min = min - pop;
            }

        }

        public int Top()
        {
            long top = stack.Peek();
            //负数的话，出栈的值保存在 min 中
            if (top < 0)
            {
                return (int)(min);
                //出栈元素加上最小值即可
            }
            else
            {
                return (int)(top + min);
            }
        }

        public int GetMin()
        {
            return (int)min;
        }
    }

    public class MinStack4
    {
        public class Node
        {
            public int value;
            public int min;
            public Node next;

            public Node(int x, int min)
            {
                this.value = x;
                this.min = min;
                next = null;
            }
        }
        Node head;
        //每次加入的节点放到头部
        public void Push(int x)
        {
            if (null == head)
            {
                head = new Node(x, x);
            }
            else
            {
                //当前值和之前头结点的最小值较小的做为当前的 min
                Node n = new Node(x, Math.Min(x, head.min));
                n.next = head;
                head = n;
            }
        }

        public void Pop()
        {
            if (head != null)
                head = head.next;
        }

        public int Top()
        {
            if (head != null)
                return head.value;
            return -1;
        }

        public int GetMin()
        {
            if (null != head)
                return head.min;
            return -1;
        }
    }



}
