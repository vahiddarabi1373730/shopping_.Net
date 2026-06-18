using Shopping_Core.Models.Order;
using Shopping_Data_Layer.Entities.Order;

namespace Shopping_Core.Services.Interfaces;

public interface IOrderService
{
    Task<Order> CreateOrder(long userId);
    Task<List<OrderResponse>> GetOrders(long userId);
    Task<Order> GetOpenOrder(long userId);
    Task<BasketResponse> GetBasket(long orderId);
    Task<OrderResponse> RemoveOrderItem(long orderId,long orderItemId);
    Task AddProductToOrder(long userId, long productId,int count);

}