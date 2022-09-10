using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class PingHelper
    {
        public static long Show(string url)
        {
            try
            {
                //Ping 实例对象;
                Ping pingSender = new Ping();
                //ping选项;
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "ping test data";
                byte[] buf = Encoding.ASCII.GetBytes(data);
                //调用同步send方法发送数据，结果存入reply对象;
                PingReply reply = pingSender.Send(url, 120, buf, options);

                //if (reply.Status == IPStatus.Success)
                //{

                //}
                return reply.RoundtripTime;
            }
            catch (Exception exp)
            {
                return 99999999;
            }
        }


    }
}
