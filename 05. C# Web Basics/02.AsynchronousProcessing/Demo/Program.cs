using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => {
                for (int i = 1; i <= 100; i++)
                {
                    HttpClient httpClient = new HttpClient();
                    var url = $"https://vicove.com/vic-{i}";
                    var httpResponse = await httpClient.GetAsync(url);
                    var vic = await httpResponse.Content.ReadAsStringAsync();
                    Console.WriteLine(vic.Length);
                }
            });

            List<int> ints= new List<int>();

            return;
            
            new Thread(() => {
                HttpClient httpClient = new HttpClient();
                for (int i = 1; i <= 100; i++)
                {
                    var url = $"https://vicove.com/vic-{i}";
                    var httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult();
                    var vic = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Console.WriteLine(vic.Length);
                }
            }).Start();

            return;
            HttpClient httpClient = new HttpClient();
            for (int i = 1; i <= 100; i++)
            {
                var url = $"https://vicove.com/vic-{i}";
                var httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult();
                var vic = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine(vic.Length);
            }
        }


        //static async Task Main(string[] args)
        //{
        //    Console.OutputEncoding = Encoding.UTF8;
        //    TcpListener tcpListener = new TcpListener(
        //        IPAddress.Loopback, 80);
        //    tcpListener.Start();
        //    while (true)
        //    {
        //        var client = tcpListener.AcceptTcpClient();
        //        ProcessClientAsync(client);
        //    }
        //}

    }
}