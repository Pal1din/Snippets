using Backend.Services;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddTransient<IRestClient>(
    _ => new RestClient(builder.Configuration.GetConnectionString("LeetCodeApi") ?? throw new ArgumentNullException()));

var app = builder.Build();

app.MapGrpcService<LeetcodeService>();
// Configure the HTTP request pipeline.
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();