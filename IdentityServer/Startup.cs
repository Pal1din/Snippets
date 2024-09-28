using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddIdentityServer()
            .AddInMemoryClients(GetClients())
            .AddInMemoryIdentityResources(GetIdentityResources())
            .AddInMemoryApiResources(GetApiResources())
            .AddInMemoryApiScopes(GetApiScopes())
            .AddTestUsers(GetUsers())
            .AddDeveloperSigningCredential()
            ;
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseIdentityServer();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    internal static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            new()
            {
                ClientId = "grpc_client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("grpc_secret".Sha256()) },
                AllowedScopes = { "grpc_api" }
            }
        };
    }

    private static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }

    private static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new("grpc_api", "GRPC API")
        };
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>
        {
            new("grpc_api", "GRPC API")
        };
    }

    private static List<TestUser> GetUsers()
    {
        return
        [
            new TestUser()
            {
                SubjectId = "1",
                Username = "alice",
                Password = "password"
            }
        ];
    }
}