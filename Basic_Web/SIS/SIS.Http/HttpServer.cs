using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {

        private readonly TcpListener tcpListener;

        //TODO: actions
        public HttpServer(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);

        }

        public async Task ResetAsync()
        {
            this.Stop();
            await this.StartAsync();
        }

        public async Task StartAsync()
        {
            tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(() => ProcessClientAsync(tcpClient));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }

        }

        public void Stop()
        {
            this.tcpListener.Stop();
        }


        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
           
            using NetworkStream networkStream = tcpClient.GetStream();
            byte[] requestBytes = new byte[1000000]; // TODO: Use buffer
            int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
            string requestAsString = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
            var request = new HttpRequest(requestAsString);
            string content = "<h1>random page</h1>";
            if (request.Path=="/")
            {
                content = "<h1>home page</h1>";
            }
            else if (request.Path == "/users/login")
            {
                content = "<h1>login page</h1>";
            }

            byte[] stringContent = Encoding.UTF8.GetBytes(content);
            var response = new HttpResponse(HttpResponseCode.OK, stringContent);
            response.Headers.Add(new Header("Server: ", "SoftUniServer/1.0"));
            response.Headers.Add(new Header("Content-Type: ","text/html"));

            //string headers = "HTTP/1.0 200 OK" + HttpConstants.NewLine +
            //                  "Server: SoftUniServer/1.0" + HttpConstants.NewLine +
            //                  "Content-Type: text/html" + HttpConstants.NewLine +
            //                  "Content-Lenght: " + stringContent.Length + HttpConstants.NewLine +
            //                  HttpConstants.NewLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());
            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
            await networkStream.WriteAsync(response.Body, 0, response.Body.Length);


            Console.WriteLine(request);
            Console.WriteLine(new string('=', 60));
        }
    }
}
