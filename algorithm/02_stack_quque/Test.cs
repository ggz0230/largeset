using System;
using System.Collections.Generic;
using System.Text;

namespace _02_stack_quque
{
    public class Test
    {
        public int Trap(int[] height)
        {

            Stack<int> stack = new Stack<int>();
            int sum = 0, curr = 0;
            while (curr < height.Length)
            {
                while (stack.Count > 0 && height[curr] > height[stack.Peek()])
                {
                    int h = height[stack.Pop()];
                    if (stack.Count == 0) break;
                    int width = curr - stack.Peek() - 1;
                    int min = Math.Min(height[curr], height[stack.Peek()]);
                    sum += width * (min - h);
                }
                stack.Push(curr++);
            }
            return sum;

        }

    }


}
