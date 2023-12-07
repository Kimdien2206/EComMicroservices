using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.DependencyInjection;
//using ECom.Services.Auth.Data;
using Microsoft.Extensions.Configuration;
using Messages.MailerMessage;
using ECom.Services.Auth.Data;
using Microsoft.EntityFrameworkCore;

namespace ECom.Services.Auth
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Auth";
            await Host.CreateDefaultBuilder(args).UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Auth");

                    var transport = endpointConfiguration.UseTransport<LearningTransport>();

                    var route = transport.Routing();

                    route.RouteToEndpoint(typeof(SendMailMessage), "Mailer");
                    
                    return endpointConfiguration;
                })
                .RunConsoleAsync();



        }
    }
}