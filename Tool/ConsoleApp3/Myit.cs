using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    interface Myit
    {
        public string Name { get; set; }
        public void Show();


    }

    class Myclass : Myit
    {
        public string Name { get; set; }

        public void Show()
        {
            Console.WriteLine(Name);
        }
    }
}
