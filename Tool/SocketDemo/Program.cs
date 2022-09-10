using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketDemo
{
    class Program
    {
        //AddressFamily 地址类型。采用IP4
        //SocketType  传输数据类型
        //ProtocolType 协议类型
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, 8002));

            socket.Listen(100);

            //接收客户端的 Socket请求   第一个参数是一个委托，第二个参数是第一个参数的参数
            socket.BeginAccept(OnAccept, socket);

            Console.WriteLine("当前web服务器启动成功,端口号为：8002");

            Console.ReadKey();
        }


        public static void OnAccept(IAsyncResult ar)
        {
            var serverSocket = ar.AsyncState as Socket;

            //客户端socket
            var clientSocket = serverSocket.EndAccept(ar);

            //服务端进行下一步监听
            serverSocket.BeginAccept(OnAccept, serverSocket);

            var bytes = new byte[1000];
            //获取客户端socket内容
            var len = clientSocket.Receive(bytes);
            //转化正字符串
            var request = Encoding.UTF8.GetString(bytes, 0, len);

            var response = string.Empty;

            if (!string.IsNullOrEmpty(request) && !request.Contains("favicon.ico"))
            {
                // /1.html
                var filePath = request.Split("\r\n")[0].Split(" ")[1].TrimStart('/');

                //获取文件内容
                response = System.IO.File.ReadAllText(filePath, Encoding.UTF8);
            }

            Console.WriteLine(request + "标识执行了");

            //按照http的响应报文返回
            var responseHeader = string.Format(@"HTTP/1.1 200 OK
Date: Sun, 26 Aug 2018 03:33:36 GMT
Server: nginx
Content-Type: text/html; charset=utf-8
Cache-Control: no-cache
Pragma: no-cache
Via: hngd_ax63.139
X-Via: 1.1 tjhtapp63.147:3800, 1.1 cbsshdf-A4-2-D-14.32:8101
Connection: keep-alive
Content-Length: {0}

", Encoding.UTF8.GetByteCount(response));

            //返回给客户端了 可以多次返回
            clientSocket.Send(Encoding.UTF8.GetBytes(responseHeader));
            clientSocket.Send(Encoding.UTF8.GetBytes(response));

            clientSocket.Close();
        }

    }
}
