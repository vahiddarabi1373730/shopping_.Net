using Shopping_Core.Models.ProductCategory;

namespace Shopping_Core.Models.Notifications;

public interface INotificationService
{
    Task CreateProductCategory(ProductCategoryResponse response);
    Task UpdateProductCategory(ProductCategoryResponse response);
}