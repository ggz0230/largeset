using System;
using System.Collections.Generic;
using System.Text;

namespace _08_DivideRule_Recall
{
    /// <summary>
    /// 50. Pow(x, n)   非常高频
    /// https://leetcode-cn.com/problems/powx-n
    /// https://leetcode.com/problems/powx-n
    /// </summary>
    public class B55_Powx_n
    {
        #region MyRegion
        /// <summary>
        /// 时间复杂度和空间复杂度 O(log n)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
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
            if (n == 0) return 1;  //递归终止条件
            double sr = FastPow(x, n / 2); //拆分问题 子问题答案
            return n % 2 == 0 ? sr * sr : sr * sr * x; //合并子问题
        }
        #endregion

        #region 快速幂法（后面讲）

        #endregion

        #region 牛顿迭代法 数学的解法 感兴趣去看

        #endregion


    }
}
