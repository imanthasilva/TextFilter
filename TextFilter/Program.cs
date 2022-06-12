using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextFilter.Interfaces;
using TextFilter.Models;
using TextFilter.Models.Filters;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var service = host.Services.GetService<IWorker>();
            
            service?.Process();
            
            Console.ReadKey();
        }
        
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IWorker, Worker>();
                    services.AddTransient<IReader, FileReader>();
                    services
                        .AddTransient<IFilter, LessThanThreeFilter>()
                        .AddTransient<IFilter, ContainsLetterTFilter>()
                        .AddTransient<IFilter, VowelInMiddleFilter>();
                });
            return hostBuilder;
        }
    }
}
