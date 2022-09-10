using System;
using System.Collections.Generic;
using System.Text;

namespace MySortAlgorithm
{
    /// <summary>
    /// 912. 排序数组  (中等)
    /// https://leetcode.com/problems/sort-an-array
    /// 排序算法 选择 插入 冒泡排序 （了解）
    /// </summary>
    public class B912_sort_array
    {
        /// <summary>
        /// 选择排序
        /// 每次找最小值，然后放到待排序数组的起始位置
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SelectionSort(int[] nums)
        {
            int len = nums.Length;
            int minIndex, temp;
            for (int i = 0; i < len - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (nums[j] < nums[minIndex]) minIndex = j;
                }
                temp = nums[i];
                nums[i] = nums[minIndex];
                nums[minIndex] = temp;
            }
            return nums;
        }
        /// <summary>
        /// 插入排序
        /// 从前到后逐步构建有序序列；对于未排序数据，在已排序序列中从后向前扫描，找到相应位置并插入
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] InsertionSort(int[] nums)
        {
            int len = nums.Length;
            int preIndex, current;
            for (int i = 0; i < len; i++)
            {
                preIndex = i - 1;
                current = nums[i];
                while (preIndex >= 0 && nums[preIndex] > current)
                {
                    nums[preIndex + 1] = nums[preIndex];
                    preIndex--;
                }
                nums[preIndex + 1] = current;
            }
            return nums;
        }

        /// <summary>
        /// 冒泡排序
        /// 嵌套循环，每次查看相邻的元素，如果逆序，则交换
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] BubbleSort(int[] nums)
        {
            #region 标准答案
            int n = nums.Length;
            if (n <= 1) return nums;
            for (int i = 0; i < n; ++i)
            {
                // 提前退出冒泡循环的标志位
                bool flag = false;
                for (int j = 0; j < n - i - 1; ++j)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int tmp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmp;
                        flag = true;  // 表示有数据交换      
                    }
                }
                if (!flag) break;  // 没有数据交换，提前退出
            }
            return nums;
            #endregion
        }

    }

    /// <summary>
    /// 快速排序 （重要）
    /// 分治思想 分而治之
    /// </summary>
    public class QuickSortSolution
    {
        //Partition 分治  pivot 中心点   counter 计数
        public int[] SortArray(int[] nums)
        {
            QuickSort(nums, 0, nums.Length - 1);
            return nums;
        }
        public void QuickSort(int[] array, int begin, int end)
        {
            if (end <= begin) return;
            int pivot = Partition(array, begin, end);
            QuickSort(array, begin, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }

        private int Partition(int[] array, int begin, int end)
        {
            int pivot = end;//标杆位置
            int counter = begin;//小于pivot的元素的个数
            for (int i = begin; i < end; i++)
            {
                if (array[i] < array[pivot])
                {
                    int temp = array[counter]; array[counter] = array[i]; array[i] = temp;
                    counter++;
                }
            }
            int temp2 = array[pivot]; array[pivot] = array[counter]; array[counter] = temp2;
            return counter;
        }
    }

    /// <summary>
    /// 归并排序 （重要）
    /// 分治思想 分而治之
    /// </summary>
    public class MergeSortSolution
    {
        public int[] SortArray(int[] nums)
        {
            MergeSort(nums, 0, nums.Length - 1);
            return nums;
        }

        public void MergeSort(int[] nums, int left, int right)
        {
            if (right <= left) return;
            int mid = (left + right) / 2;

            MergeSort(nums, left, mid);
            MergeSort(nums, mid + 1, right);

            int[] temp = new int[right - left + 1];//中间数组
            int i = left, j = mid + 1, k = 0;
            while (i <= mid && j <= right)
            {
                temp[k++] = nums[i] <= nums[j] ? nums[i++] : nums[j++];
            }
            while (i <= mid) temp[k++] = nums[i++];
            while (j <= right) temp[k++] = nums[j++];
            for (int p = 0; p < temp.Length; p++)
            {
                nums[left + p] = temp[p];
            }
        }

    }

}
