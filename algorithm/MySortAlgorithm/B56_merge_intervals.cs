using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySortAlgorithm
{
    /// <summary>
    /// 56. 合并区间
    /// https://leetcode-cn.com/problems/merge-intervals
    /// </summary>
    public class B56_merge_intervals
    {
        /// <summary>
        /// 先排序 开数组 不合并/合并 截取结果返回
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 1) return intervals;

            Array.Sort(intervals, (v1, v2) => v1[0] - v2[0]);
            int[][] res = new int[intervals.Length][];
            res[0] = intervals[0];
            int idx = 0;
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] > res[idx][1])
                    res[++idx] = intervals[i];
                else
                    res[idx][1] = Math.Max(res[idx][1], intervals[i][1]);
            }

            int[][] ans = new int[idx + 1][];
            Array.Copy(res, ans, idx + 1);
            return ans;
        }

        public int[][] Merge2(int[][] intervals)
        {
            if (intervals.Length <= 1) return intervals;

            var result = new List<int[]>();

            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            result.Add(intervals[0]);

            for (var i = 1; i < intervals.Length; i++)
            {
                var last = result.Last();
                if (intervals[i][0] <= last[1])
                    last[1] = Math.Max(last[1], intervals[i][1]);
                else
                    result.Add(intervals[i]);
            }

            return result.ToArray();
        }

    }
}
