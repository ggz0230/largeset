using System;
using System.Collections.Generic;
using System.Text;

namespace MySortAlgorithm
{
    /// <summary>
    /// 1122. 数组的相对排序
    /// https://leetcode-cn.com/problems/relative-sort-array
    /// </summary>
    public class A1122_relative_sort_array
    {
        /// <summary>
        /// 计数排序 数组容量已经且小（本题是0-1000） 简单快速解决
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int[] arr = new int[1001];
            int[] res = new int[arr1.Length];
            int index = 0;
            foreach (int item in arr1) arr[item]++;//统计arr1

            foreach (int item in arr2)
            {
                while (arr[item]-- > 0)
                {
                    res[index++] = item;
                }
            }

            for (int i = 0; i < 1001; ++i)
            {
                while (arr[i]-- > 0)
                {
                    res[index++] = i;
                }
            }

            return res;

        }


    }
}
