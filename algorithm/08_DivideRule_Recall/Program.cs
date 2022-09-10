using System;
using System.Collections.Generic;

namespace _08_DivideRule_Recall
{
    class Program
    {
        /// <summary>
        /// 第08课丨分治、回溯
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            List<int> list = new List<int>() { 1, 2, 3 };
            list.RemoveAt(list.Count-1);


            B78_Subsets ss = new B78_Subsets();
            ss.Subsets2(new int[] { 1,2,3});
            Console.WriteLine("Hello World!");
        }
    }
}
