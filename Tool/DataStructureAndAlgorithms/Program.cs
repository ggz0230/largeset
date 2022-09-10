using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithms
{

    //数据结构和算法
    class Program
    {
        static void Main(string[] args)
        {

            //算法
            int[] A = new int[] { 4, 7, 3, 9, 5, 2, 6, 8, 1 };
            QuickSort(A, 0, A.Length - 1);
            foreach (var item in A)
            {
                Console.Write(item + "   ");
            }



        }

        #region 快速排序
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="A">数组</param>
        /// <param name="p">左边下标</param>
        /// <param name="r">右边下标</param>
        public static void QuickSort(int[] A, int p, int r)
        {
            if (p >= r)
            {
                return;
            }
            int q = Partition(A, p, r);
            QuickSort(A, p, q - 1);
            QuickSort(A, q + 1, r);
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="A">数组</param>
        /// <param name="p">左边下标</param>
        /// <param name="r">右边下标</param>
        public static int Partition(int[] A, int p, int r)
        {
            int pivot = A[r];
            int i = p;
            for (int j = p; j <= r - 1; j++)
            {
                if (A[j] < pivot)
                {
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                    i++;
                }
            }
            int temp2 = A[i];
            A[i] = A[r];
            A[r] = temp2;

            return i;
        }
        #endregion

        #region 归并排序
        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="first"></param>
        /// <param name="end"></param>
        public static void MergeSort(int[] arr, int first, int end)
        {
            //递归终止条件
            if (first >= end) return;

            //取中间位置
            int middle = (first + end) / 2;
            //分治递归
            MergeSort(arr, first, middle);
            MergeSort(arr, middle + 1, end);

            Merge(arr, first, end, middle);
        }
        /// <summary>
        /// 归并排序 合并
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="first"></param>
        /// <param name="end"></param>
        /// <param name="middle"></param>
        public static void Merge(int[] arr, int first, int end, int middle)
        {
            int leftIndex = first;//左表起始位置
            int rightIndex = middle + 1;//右表起始位置
            int k = 0;
            int[] temp = new int[arr.Length];

            while (leftIndex <= middle && rightIndex <= end)
            {
                if (arr[leftIndex] <= arr[rightIndex])
                {
                    temp[k] = arr[leftIndex];
                    k++;
                    leftIndex++;
                }
                else
                {
                    temp[k] = arr[rightIndex];
                    k++;
                    rightIndex++;
                }
            }
            if (leftIndex <= middle)
            {
                for (int i = leftIndex; i <= middle; i++)
                {
                    temp[k] = arr[i];
                    k++;
                }
            }
            if (rightIndex <= end)
            {
                for (int i = rightIndex; i <= end; i++)
                {
                    temp[k] = arr[i];
                    k++;
                }
            }

            k = 0;
            for (int i = first; i <= end; i++)
            {
                arr[i] = temp[k];
                k++;
            }
        }
        #endregion

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="a"></param>
        public static void BubbleSort(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                bool flag = false;//提前退出冒泡循环的标志位
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        flag = true;//表示有数据交换
                    }
                }
                if (!flag)
                {
                    break;//没有数据交换，提前退出
                }
            }
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="a"></param>
        public static void InsertionSort(int[] a)
        {
            int n = a.Length;
            for (int i = 1; i < n; i++)
            {
                int value = a[i];
                int j = i - 1;
                for (; j >= 0; j--)
                {
                    if (a[j] > value)
                        a[j + 1] = a[j];
                    else
                        break;
                }
                a[j + 1] = value;
            }
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="a"></param>
        public static void SelectSort(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minVal = a[i];  //先假设最小值
                int minIndex = i;     //先假设最小值的下标
                //找出这一趟最小的数值并记录下它的下标
                for (int j = i + 1; j < n; j++)
                {
                    if (minVal > a[j])
                    {
                        minVal = a[j];
                        minIndex = j;
                    }
                }
                //最后把最小的数与已排序的末尾交换
                int temp = a[i];
                a[i] = a[minIndex];
                a[minIndex] = temp;
            }
        }


    }
}
