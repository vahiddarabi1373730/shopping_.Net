
using Shopping_Core.Models.OrderItem;

namespace Shopping_Core.Models.Order;

public class OrderResponse
{
    public long Id { get; set; }
    public string  FullName { get; set; }
    public DateTime  CreateDate { get; set; }
    public bool IsPay { get; set; }
    public DateTime PaymentDate { get; set; }
    public List<OrderItemResponse> OrderItemResponse { get; set; }

}