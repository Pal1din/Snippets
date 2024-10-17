using Backend.Services;
using IdentityOrm;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();
builder.Services.AddDbContext<MyIdentityDbContext>(optionsBuilder => 
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddIdentityOrm()
    .AddApiEndpoints();

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.Services.AddTransient<IRestClient>(
    _ => new RestClient(builder.Configuration.GetConnectionString("LeetCodeApi") ?? throw new ArgumentNullException()));

var app = builder.Build();
app.MapIdentityApi<User>();
app.MapGrpcReflectionService();

app.MapGrpcService<LeetcodeService>();
app.Run();