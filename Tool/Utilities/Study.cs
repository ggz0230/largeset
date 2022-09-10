using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    public class Study
    {
        string a = "aaaa", b = "bbbb";
        public void Seta()
        {
            lock (b)
            {
                a = "bbbb";
            }
        }
        public void Setb()
        {
            lock (a)
            {
                b = "aaaa";
            }
        }

        public void Show()
        {
            Thread t = new Thread(Seta);
            Thread.Sleep(5000);
            t.Start();
            Thread t2 = new Thread(Setb);
            Thread.Sleep(5000);
            t2.Start();
        }



        
    }
}
