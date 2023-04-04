using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Demo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            // daemon // service
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[10000000];
                    var length = stream.Read(buffer, 0, buffer.Length);

                    string requestString =
                        Encoding.UTF8.GetString(buffer, 0, length);
                    Console.WriteLine(requestString);


                    bool sessionSet = false;
                    if (requestString.Contains("sid="))
                    {
                        sessionSet = true;
                    }


                    string html = "<h1>Hello world!!!!!!</h1>";
                    string response = "HTTP/1.1 200 OK" + NewLine +
                        "Server: GeorgiServer 2020" + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        "Content-Length: " + html.Length + NewLine +
                        //(!sessionSet ? ("Set-Cookie: sid=s3539603760pQrT; Expires: 1601054590" + NewLine) : string.Empty) +
                        (!sessionSet ? ("Set-Cookie: sid=s3539603760pQrT; Expires=" + DateTime.UtcNow.AddHours(3).ToString("R") + NewLine) : string.Empty) +
                        NewLine +
                        html;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('-', 70));
                }
            }
        }

    }
}