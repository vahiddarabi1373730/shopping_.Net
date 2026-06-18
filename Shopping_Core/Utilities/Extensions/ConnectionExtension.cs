
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopping_Data_Layer.Context;

namespace Shopping_Core.Utilities.Extensions;

public static class ConnectionExtension
{
    public static IServiceCollection AddConnectionStrings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ShoppingContext>(options =>
        {
            var connectionString = "ConnectionStrings:ShoppingConnection:Development";
            options.UseSqlServer(configuration[connectionString]);
        });

        return services;
    }
}