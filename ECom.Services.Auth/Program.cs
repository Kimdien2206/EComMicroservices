using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.DependencyInjection;
//using ECom.Services.Auth.Data;
using Microsoft.Extensions.Configuration;

namespace ECom.Services.Auth
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Auth";
            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Auth");

                    endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();


                    return endpointConfiguration;
                })
                .RunConsoleAsync();

        }
    }
}