using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ECom.Services.Sales
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Sales";
            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Sales");

                    endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();

                    return endpointConfiguration;
                })
                .RunConsoleAsync();

        }
    }
}