using Messages.ReportMessages;
using Microsoft.Extensions.Hosting;

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
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();

                    var transport = endpointConfiguration.UseTransport<LearningTransport>();

                    var route = transport.Routing();

                    route.RouteToEndpoint(typeof(GetForecastByProductId), "Forecast");


                    return endpointConfiguration;
                })
                .RunConsoleAsync();

        }
    }
}