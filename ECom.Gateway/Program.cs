using Messages.CollectionMessages;
using Messages.DiscountMessages;
using Messages.ProductMessages;
using Messages.TagMessages;
using Messages.AuthMessages;
using Messages.OrderMessages;
using Messages.ReceiptMessages;
using Messages.ReportMessages;

Console.Title = "Gateway";
var builder = WebApplication.CreateBuilder(args);

// Add NServiceBus

builder.Host.UseNServiceBus(context =>
{
    var endpointConfiguration = new EndpointConfiguration("Gateway");
    endpointConfiguration.EnableCallbacks();
    endpointConfiguration.MakeInstanceUniquelyAddressable("A");
    endpointConfiguration.UseSerialization<SystemJsonSerializer>();


    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    var route = transport.Routing();

    route.RouteToEndpoint(typeof(GetAllProduct), "Product");
    route.RouteToEndpoint(typeof(ViewProduct), "Product");
    route.RouteToEndpoint(typeof(CreateProduct), "Product");
    route.RouteToEndpoint(typeof(GetBestSellers), "Product");
    route.RouteToEndpoint(typeof(GetMostViewed), "Product");
    route.RouteToEndpoint(typeof(GetProductBySlug), "Product");
    route.RouteToEndpoint(typeof(GetProductByItemID), "Product");
    route.RouteToEndpoint(typeof(UpdateProduct), "Product");
    route.RouteToEndpoint(typeof(GetAllDiscount), "Product");
    route.RouteToEndpoint(typeof(CreateDiscount), "Product");
    route.RouteToEndpoint(typeof(DeleteDiscount), "Product");
    route.RouteToEndpoint(typeof(UpdateDiscount), "Product"); 
    route.RouteToEndpoint(typeof(GetAllCollection), "Product");
    route.RouteToEndpoint(typeof(CreateCollection), "Product");
    route.RouteToEndpoint(typeof(DeleteCollection), "Product");
    route.RouteToEndpoint(typeof(UpdateCollection), "Product"); 
    route.RouteToEndpoint(typeof(GetAllTag), "Product");
    route.RouteToEndpoint(typeof(CreateTag), "Product");
    route.RouteToEndpoint(typeof(DeleteTag), "Product");
    route.RouteToEndpoint(typeof(UpdateTag), "Product"); 
    route.RouteToEndpoint(typeof(GetAllOrder), "Sales");
    route.RouteToEndpoint(typeof(GetOrderByStatus), "Sales");
    route.RouteToEndpoint(typeof(UpdateOrderStatus), "Sales");
    route.RouteToEndpoint(typeof(CreateOrder), "Sales");
    route.RouteToEndpoint(typeof(GetYearlyReport), "Reports");
    route.RouteToEndpoint(typeof(GetReceiptByStatus), "Billing");
    route.RouteToEndpoint(typeof(CreateReceipt), "Billing");
    route.RouteToEndpoint(typeof(PaidReceipt), "Billing");
    route.RouteToEndpoint(typeof(LoginMessage), "Auth");


    return endpointConfiguration;
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
