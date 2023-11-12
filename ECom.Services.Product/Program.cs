using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.DependencyInjection;
using ECom.Services.Products.Data;
using Microsoft.Extensions.Configuration;

namespace ECom.Services.Products
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Product";
            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Product");

                    endpointConfiguration.UseTransport<LearningTransport>();

                    return endpointConfiguration;
                })
                .RunConsoleAsync();

        }
    }
}