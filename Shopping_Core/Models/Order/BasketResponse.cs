using Shopping_Core.Models.OrderItem;

namespace Shopping_Core.Models.Order;

public class BasketResponse
{
    public long OrderId { get; set; }
    public List<OrderItemResponse> OrderItemResponses { get; set; }
    public decimal SumOrderItemsPrice { get; set; }
    public decimal SendPay { get; set; }
}