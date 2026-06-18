using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopping_Data_Layer.Context;
using Shopping_Data_Layer.Data;

namespace Shopping_Core.Utilities.Extensions;

public static class SeedDataExtension
{
    public static async Task SeedDataAsync(this IHost host)
    {
        await using var scop=host.Services.CreateAsyncScope();
        var context = scop.ServiceProvider.GetRequiredService<ShoppingContext>();
        await Seeder.AddProductSeedData(context);
    }
}