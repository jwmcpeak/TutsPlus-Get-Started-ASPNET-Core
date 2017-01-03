using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace ConsoleApplication
{
    public class Program
    {
        private static string _name;
        public static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            _name= Console.ReadLine();

            var host = new WebHostBuilder()
                .UseKestrel()
                .Configure(app => app.Run(HandleRequest))
                .Build();

                host.Run();
        }

        public static async Task HandleRequest(HttpContext context) {
            await context.Response.WriteAsync($"Hello {_name}");
        }
    }
}
