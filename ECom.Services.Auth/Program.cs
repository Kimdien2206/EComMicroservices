//using ECom.Services.Auth.Data;
using Messages.MailerMessage;
using Messages.UserMessages;
using Microsoft.Extensions.Hosting;

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
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();


                    var route = transport.Routing();

                    route.RouteToEndpoint(typeof(SendMailMessage), "Mailer");
                    route.RouteToEndpoint(typeof(GetAllUsersResponse), "Recommendation");

                    return endpointConfiguration;
                })
                .RunConsoleAsync();



        }
    }
}