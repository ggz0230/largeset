using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyTest myTest = new MyTest();
            //myTest.Show();
            string str = "中国共产党";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(str);

            string cc = System.Text.Encoding.UTF8.GetString(byteArray);

        }
    }


    public class MyTest
    {
        public void Show()
        {
            Console.WriteLine("111 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            AsyncMethod();
            Console.WriteLine("222 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
        }

        private async Task AsyncMethod()
        {
            var ResultFromTimeConsumingMethod = TimeConsumingMethod();
            string Result = await ResultFromTimeConsumingMethod + " + AsyncMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(Result);
            //返回值是Task的函数可以不用return
        }

        //这个函数就是一个耗时函数，可能是IO操作，也可能是cpu密集型工作。
        private Task<string> TimeConsumingMethod()
        {
            var task = Task.Run(() =>
            {
                Console.WriteLine("Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                Console.WriteLine("Helo I am TimeConsumingMethod after Sleep(5000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                return "Hello I am TimeConsumingMethod";
            });

            return task;
        }

    }
}
