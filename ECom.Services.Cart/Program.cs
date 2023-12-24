using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ECom.Services.Cart
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Cart";
            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Cart");

                    endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();


                    return endpointConfiguration;
                })
                .RunConsoleAsync();

        }
    }
}