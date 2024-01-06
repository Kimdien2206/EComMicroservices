using System.Text;
using Messages.AuthMessages;
using Messages.CartMessages;
using Messages.CollectionMessages;
using Messages.DiscountMessages;
using Messages.ForecastMessage;
using Messages.ImportingMessages;
using Messages.OrderMessages;
using Messages.ProductMessages;
using Messages.ReceiptMessages;
using Messages.RecommendMessages;
using Messages.ReportMessages;
using Messages.TagMessages;
using Messages.UserMessages;
using Messages.VoucherMessage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
    route.RouteToEndpoint(typeof(GetAllImporting), "Product");
    route.RouteToEndpoint(typeof(CreateImporting), "Product");

    route.RouteToEndpoint(typeof(GetAllOrdersByPhonenumber), "Sales");
    route.RouteToEndpoint(typeof(GetOrderByStatus), "Sales");
    route.RouteToEndpoint(typeof(UpdateOrderStatus), "Sales");
    route.RouteToEndpoint(typeof(CreateOrder), "Sales");
    route.RouteToEndpoint(typeof(GetOrderById), "Sales");

    route.RouteToEndpoint(typeof(GetYearlyReport), "Reports");
    route.RouteToEndpoint(typeof(GetReceiptByStatus), "Billing");
    route.RouteToEndpoint(typeof(CreateReceipt), "Billing");
    route.RouteToEndpoint(typeof(PaidReceipt), "Billing");
    route.RouteToEndpoint(typeof(CreateVNPayUrl), "Billing");
    route.RouteToEndpoint(typeof(ValidateReceiptPayment), "Billing");
    route.RouteToEndpoint(typeof(LoginMessage), "Auth");
    route.RouteToEndpoint(typeof(ResetCodeCommand), "Auth");
    route.RouteToEndpoint(typeof(ResetPasswordCommand), "Auth");
    route.RouteToEndpoint(typeof(GetAllUser), "Auth");
    route.RouteToEndpoint(typeof(UserLoggedIn), "Auth");
    route.RouteToEndpoint(typeof(UpdateUser), "Auth");
    route.RouteToEndpoint(typeof(RegisterCommand), "Auth");

    route.RouteToEndpoint(typeof(GetAllVoucherCommand), "Product");
    route.RouteToEndpoint(typeof(CreateVoucherCommand), "Product");
    route.RouteToEndpoint(typeof(UpdateVoucherCommand), "Product");
    route.RouteToEndpoint(typeof(DeleteVoucherCommand), "Product");

    route.RouteToEndpoint(typeof(GetForecastByProductId), "Forecast");
    route.RouteToEndpoint(typeof(TrainForecastCommand), "Forecast");

    route.RouteToEndpoint(typeof(GetCartByUser), "Cart");
    route.RouteToEndpoint(typeof(CreateCart), "Cart");
    route.RouteToEndpoint(typeof(UpdateQuantity), "Cart");
    route.RouteToEndpoint(typeof(RemoveCart), "Cart");

    route.RouteToEndpoint(typeof(TrainRecommenderModelCommand), "Recommendation");
    route.RouteToEndpoint(typeof(GetRecommendedProductCommand), "Recommendation");

    return endpointConfiguration;
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
