using Microsoft.AspNetCore.SignalR;
using Shopping_Api.Hubs;
using Shopping_Core.Models.Notifications;
using Shopping_Core.Models.ProductCategory;

namespace Shopping_Api.Services;

public class NotificationService(IHubContext<NotificationHub> hubContext):INotificationService
{
    public async Task CreateProductCategory(ProductCategoryResponse response)
    {
        await hubContext.Clients.All.SendAsync("CreatedProductCategory", response);
    }

    public async Task UpdateProductCategory(ProductCategoryResponse response)
    {
        await hubContext.Clients.All.SendAsync("UpdatedProductCategory", response);
    }
}