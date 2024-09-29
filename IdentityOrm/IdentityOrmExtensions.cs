using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityOrm;

public static class IdentityOrmExtensions
{
    public static IdentityBuilder AddIdentityOrm(this IServiceCollection services)
    {
        var addEntityFrameworkStores = services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<MyIdentityDbContext>();
        return addEntityFrameworkStores;
    }
}