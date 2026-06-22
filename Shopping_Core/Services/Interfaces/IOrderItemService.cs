using Shopping_Core.Models.OrderItem;
using Shopping_Data_Layer.Entities.Order;

namespace Shopping_Core.Services.Interfaces;

public interface IOrderItemService
{
    Task AddOrderItem(OrderItem orderItem);
    Task<List<OrderItemResponse>> GetOrderItemsResponse(long orderId);
    Task<int> GetOrderItemsResponseCount(long orderId);
    Task<List<OrderItem>> GetOrderItems(long orderId);
    Task<bool> UpdateOrderItem(OrderItem orderItem);
    Task<bool> RemoveOrderItem(long orderItemId);
}