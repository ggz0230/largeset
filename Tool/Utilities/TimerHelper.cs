using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    public class TimerHelper
    {

        public void Show()
        {
            System.Timers.Timer t = new System.Timers.Timer(2000);//实例化Timer类，设置时间间隔
            t.Elapsed += new System.Timers.ElapsedEventHandler(Method2);//到达时间的时候执行事件
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件
            while (true)
            {
                Console.WriteLine("test_" + Thread.CurrentThread.ManagedThreadId.ToString());
                Thread.Sleep(2000);
            }

        }

        public void Method2(object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString() + "_" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}
