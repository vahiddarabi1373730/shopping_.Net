namespace Shopping_Core.Models.OrderItem;

public class OrderItemResponse
{
    public long  Id { get; set; }
    public long  ProductId { get; set; }
    public int Count { get; set; }
    public string ProductName { get; set; }
    public string ImageName { get; set; }
    public decimal Price { get; set; }
}