using Messages.ProductMessages;
using Microsoft.Extensions.Hosting;

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

                    var transpot = endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();

                    var route = transpot.Routing();

                    route.RouteToEndpoint(typeof(GetAllProductIdsResponse), "Forecast");
                    route.RouteToEndpoint(typeof(GetAllProductItemsResponse), "Recommendation");

                    return endpointConfiguration;
                })
                .RunConsoleAsync();

        }
    }
}