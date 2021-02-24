using Microsoft.Owin.Hosting;
using SelfHost_WebApi;
using static System.Console;

namespace SelfHost_App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:5000"))
            {
                WriteLine("Usando Self-Host em uma aplicação Console...");
                ReadLine();
            }
        }
    }
}
