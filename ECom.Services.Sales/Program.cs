using Messages.OrderMessages;
using Microsoft.Extensions.Hosting;

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

                    var tranport = endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();

                    var route = tranport.Routing();

                    route.RouteToEndpoint(typeof(GetAllOrdersResponse), "Recommendation");

                    return endpointConfiguration;
                })
                .RunConsoleAsync();
        }
    }
}