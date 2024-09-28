using IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential() 
    .AddInMemoryApiScopes(Startup.GetApiScopes())
    .AddInMemoryClients(Startup.GetClients());

var app = builder.Build();

app.UseRouting();

app.UseIdentityServer();
app.MapControllers();

app.Run();