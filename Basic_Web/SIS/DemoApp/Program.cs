using SIS.HTTP;
using System;
using System.Threading.Tasks;

namespace DemoApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Actions:
            // /=> respones IndexPage(request)
            // /favicon.ico=>favicon.ico
            // GET/Contact => respones ShowCOntactForm(requqest)
            // POST /Contact=> response FillContactForm(request)

            var httpServer = new HttpServer(80);
          await httpServer.StartAsync();
            //.Start
        }
    }
}
