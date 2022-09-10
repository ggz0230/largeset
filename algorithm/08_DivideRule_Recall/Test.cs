using System;
using System.Collections.Generic;
using System.Text;

namespace _08_DivideRule_Recall
{
    public class Test
    {
        public double MyPow(double x, int n)
        {
            if (n < 0)
            {
                return FastPow(1 / x, -n);
            }
            else
            {
                return FastPow(x, n);
            }
        }

        private double FastPow(double x, int n)
        {
            if (n == 0) return 1;
            double sr = FastPow(x, n / 2);
            return n % 2 == 0 ? sr * sr : sr * sr * x;
        }


        public IList<IList<int>> Subsets2(int[] nums)
        {

            IList<IList<int>> ans = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return ans;

            ans.Add(new List<int>());

            foreach (var num in nums)
            {
                int cnt = ans.Count;

                for (int i = 0; i < cnt; i++)
                {
                    ans.Add(new List<int>(ans[i]) { num });
                }
            }
            return ans;
        }

    }
}
