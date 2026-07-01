using Shopping_Core.Models.Order;
using Shopping_Core.Models.OrderItem;
using Shopping_Data_Layer.Entities.Order;

namespace Shopping_Core.Services.Interfaces;

public interface IOrderService
{
    Task<Order> CreateOrder(long userId);
    Task<List<OrderResponse>> GetUserOrders(long userId);
    Task<List<OrderResponse>> GetOrders(long userId);
    Task<List<OrderItemResponse>> GetOrderItemsByOrderId(long orderId);
    Task<int> GetOrderItemsCountByOrderId(long orderId);
    Task<int> GetOrdersCount();
    Task<Order> GetOpenOrder(long userId);
    Task<BasketResponse> GetBasket(long orderId);
    Task<bool> PayBasket(long orderId , long userId);
    Task<OrderResponse> RemoveOrderItem(long orderId,long orderItemId,long userId);
    Task<long> AddProductToOrder(long userId, long productId,int count);

}