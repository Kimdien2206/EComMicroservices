
using Messages;

var builder = WebApplication.CreateBuilder(args);

// Add NServiceBus

builder.Host.UseNServiceBus(context =>
{
    var endpointConfiguration = new EndpointConfiguration("Gateway");
    endpointConfiguration.EnableCallbacks();
    endpointConfiguration.MakeInstanceUniquelyAddressable("A");

    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    var route = transport.Routing();

    route.RouteToEndpoint(typeof(GetAllProduct), "Product");

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
