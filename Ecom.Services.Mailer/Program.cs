using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Messages.MailerMessage;
using System.Security.Cryptography.Xml;
using Dto.AuthDto;

namespace ECom.Services.Mailer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Mailer";
            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Mailer");

                    var transport = endpointConfiguration.UseTransport<LearningTransport>();

                    return endpointConfiguration;
                })
                .RunConsoleAsync();

        }
    }
}