using System;
using System.Collections;
using System.Collections.Generic;

namespace _03_hash_map
{
    class Program
    {
        static void Main(string[] args)
        {

            //HashSet<int> h = new HashSet<int>();
            //h.Add(1);
            //h.Add(2);
            //h.Add(3);

            Dictionary<int, int> dics = new Dictionary<int, int>();
            dics.Add(1, 2);
            dics.Add(1, 3);
            dics.Add(2, 3);
            



            //ValidAnagram validAnagram = new ValidAnagram();
            //validAnagram.IsAnagram2("anagram", "nagaram");

            Console.ReadKey();
        }
    }
}
