using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HTTP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n";
            TcpListener tcp = new TcpListener(IPAddress.Loopback, 1234);

            tcp.Start();

            while (true)
            {
                TcpClient client = tcp.AcceptTcpClient();
                using (NetworkStream networkStream = client.GetStream())
                {
                    byte[] requestBytes = new byte[10000000];
                    //TODO: use buffer

                    int bytesRead = networkStream.Read(requestBytes, 0, requestBytes.Length);
                    string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
                    string responseText = @"<form action='/Account/Login' method='post'>
<input type=date name='date' />
<input type=text name='username' />
<input type=password name='pasword' />
<input type=submit value='Login' />
</form>"; 
                    string respone = "HTTP/1.1 200 OK" + NewLine +
                        "Server: SoftUniServer/1.0" + NewLine +
                        "Content-Type: text/html" + NewLine +                        
                        "Content-Disposition: attachment; filename=vera.html" + NewLine+
                        "Content-Lenght: " + responseText.Length + NewLine +
                        NewLine +
                        responseText;
                    byte[] responesBytes = Encoding.UTF8.GetBytes(respone);
                    networkStream.Write(responesBytes, 0, responesBytes.Length);
                    Console.WriteLine(request);
                    Console.WriteLine(new string('=', 60));
                } 
                
            }
        }

        private static async Task HttpMethod()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage responseMessage = await client.GetAsync("https://softuni.bg/");

            string result = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}
