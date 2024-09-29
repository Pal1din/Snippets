using IdentityOrm;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();

builder.Services.AddDbContext<MyIdentityDbContext>(optionsBuilder => 
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddIdentityOrm()
    .AddApiEndpoints();
var app = builder.Build();
app.MapIdentityApi<User>();
app.Run();

