using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Threading;
using static System.Console;

namespace SelfHost_WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            Thread t = new Thread(DoCommand);
            t.Start();

            // Inicia o host OWIN 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                ////Cria um HttpCient e faz uma requisição para api/universo 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/universo").Result;

                WriteLine(response);
                WriteLine(response.Content.ReadAsStringAsync().Result);
                WriteLine("Web Api Self-Host....");
                ReadLine();
            }
        }

        private static void DoCommand()
        {
            while (true)
            {
                lock (Startup.command)
                {
                    if(Startup.command.Count > 0)
                    {
                        Console.WriteLine(Startup.command.Dequeue());
                    }
                }
            }
        }
    }
}
