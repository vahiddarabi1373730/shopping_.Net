using Microsoft.AspNetCore.Mvc;
using Shopping_Core.Models.Order;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;
using Shopping_Core.Utilities.Extensions;

namespace Shopping_Api.Controllers;

public class OrderController(IOrderService orderService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddProductToOrder([FromBody] AddProductToOrderRequest addProductToOrderRequest)
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            var userId = User.CheckAuthUser();
            await orderService.AddProductToOrder(userId, addProductToOrderRequest.ProductId,
                addProductToOrderRequest.Count);
            return JsonResponse.Success("درخواست با موفقیت اجرا شد");
        }

        return JsonResponse.Error("درخواست با خطا روبه رو شد");
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserOrders(long userId)
    {
        var ordersResponse = await orderService.GetUserOrders(userId);
        return JsonResponse.Success(ordersResponse);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var userId = User.CheckAuthUser();
        var ordersResponse = await orderService.GetOrders(userId);
        return JsonResponse.Success(ordersResponse);
    }
    
    [HttpGet("count")]
    public async Task<IActionResult> GetOrdersCount()
    {
        var ordersResponse = await orderService.GetOrdersCount();
        return JsonResponse.Success(ordersResponse);
    }
    
    
    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderItems(long orderId)
    {
        var items = await orderService.GetOrderItemsByOrderId(orderId);
        return JsonResponse.Success(items);
    }
    
    
    [HttpGet("{orderId}/count")]
    public async Task<IActionResult> GetOrderItemsCount(long orderId)
    {
        var items = await orderService.GetOrderItemsCountByOrderId(orderId);
        return JsonResponse.Success(items);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetBasket(long orderId)
    {
        var basketResponse = await orderService.GetBasket(orderId);
        return JsonResponse.Success(basketResponse);
    }

    [HttpDelete("orders/{orderId}/items/{orderItemId}")]
    public async Task<IActionResult> GetBasket(long orderId, long orderItemId)
    {
        var userId = User.CheckAuthUser();
        var orderResponse = await orderService.RemoveOrderItem(orderId, orderItemId,userId);
        if (orderResponse is null)
        {
            return JsonResponse.Error("درخواست با خطا روبه رو شد");
        }

        return JsonResponse.Success(orderResponse);
    }
}