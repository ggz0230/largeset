using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 493. 翻转对
    /// https://leetcode-cn.com/problems/reverse-pairs/
    /// </summary>
    public class C493_reverse_pairs
    {
        public int ReversePairs(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            return MergeSort(nums, 0, nums.Length - 1);
        }

        private int MergeSort(int[] nums, int left, int right)
        {
            if (left >= right) return 0;
            int mid = (right + left) / 2;
            int count = MergeSort(nums, left, mid) + MergeSort(nums, mid + 1, right);

            int[] temp = new int[right - left + 1];
            int i = left, t = left, k = 0;
            for (int j = mid + 1; j <= right; j++, k++)
            {
                while (i <= mid && nums[i] <= 2 * (long)nums[j]) i++;         //a.不符合条件的
                while (t <= mid && nums[t] < nums[j]) temp[k++] = nums[t++]; //1.假如前面的数组小于后面数组的第一个就先把前面数组排进去
                temp[k] = nums[j]; //2.排后面的数组
                count += mid - i + 1; //b.减去不符合条件+1 得到符合条件的
            }
            while (t <= mid) temp[k++] = nums[t++];//3.假如前面的数组还有剩余，那就是比较大的，所以依次排进去

            for (int p = 0; p < temp.Length; p++)
            {
                nums[left + p] = temp[p];
            }
            return count;
        }

    }

}
