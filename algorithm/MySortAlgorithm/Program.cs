using System;

namespace MySortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n");
            Console.WriteLine("111");

            int[] arr = { 1, 2, 3 };
            int[] arr2 = new int[2];
            Array.Copy(arr, arr2, 2);

            Console.WriteLine(arr2);

            Console.ReadKey();
        }
    }
}
