using System;
using System.Collections.Generic;
using System.Threading;

namespace StudyThread
{
    class Program
    {


        static void Main(string[] args)
        {
            
            while (true)
            {
                new Thread(Work).Start();
            }
            Console.WriteLine("....");
        }

        static void Work()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            string data = "{\"UserName\":\"eb474569a505fec74136be1557fe651a\",\"Password\":\"cacd1b1aa366b5f0d4e61b09da1a9cea\",\"UUID\":\"\",\"VerificationCode\":\"\"}";
            string apiurl = "https://info2api.paxsz.com/api/Hr_Employee/login";
        
            string res =  HttpHelper.PostAsyncJson(apiurl, data).Result;
            Console.WriteLine(res);
        }

    }
}
