using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ECom.Services.Reports
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Reports";
            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Reports");

                    endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();


                    return endpointConfiguration;
                })
                .RunConsoleAsync();

        }
    }
}