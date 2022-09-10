using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _01ArrayLinkedList
{
    class Program
    {
        //21 88 1 66
        static void Main(string[] args)
        {
            var dic = new Dictionary<int, int>();

            //dic.Add(1, 11);
            //dic.Add(2, 22);
            //dic.Add(3, 33);
            //dic.Add(1, 2);
            dic[1] = 11;
            dic[2] = 22;
            dic[3] = 33;
            dic[1] = 111;



            Console.ReadKey();
        }


    }



}
