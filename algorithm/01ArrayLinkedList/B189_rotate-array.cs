using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 189. 旋转数组
    /// https://leetcode-cn.com/problems/rotate-array/
    /// </summary>
    public class B189_rotate_array
    {
        /// <summary>
        /// 
        /// 空间复杂度O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            int len = nums.Length;
            k = k % len;
            int count = 0;         // 记录交换位置的次数，n个同学一共需要换n次
            for (int start = 0; count < len; start++)
            {
                int curIndex = start;       // 从0位置开始换位子
                int pre = nums[curIndex];
                do
                {
                    int nextIndex = (curIndex + k) % len;
                    int temp = nums[nextIndex];    // 来到角落...
                    nums[nextIndex] = pre;
                    pre = temp;
                    curIndex = nextIndex;
                    count++;
                } while (start != curIndex);     // 循环暂停，回到起始位置，角落无人
            }
            // len  数组长度
            // k    k%len
            // cur  当前指针
            // pre  前一个的值
            // next 下一个 用公式求得
            // temp 交换数值用
            // count 总共执行了多少此交换
            // start 循环初始位置
        }
    }
}
