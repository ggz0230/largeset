using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySortAlgorithm
{
    public class Test
    {

        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0) return intervals;

            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            List<int[]> list = new List<int[]>() { intervals[0] };

            for (int i = 1; i < intervals.Length; i++)
            {
                var last = list.Last();
                if (intervals[i][0] > last[1]){
                    list.Add(intervals[i]);
                }
                else
                {
                    last[1] = Math.Max(last[1], intervals[i][1]);
                }
            }

            return list.ToArray();
        }

    }
}
