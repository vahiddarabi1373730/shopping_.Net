using Microsoft.EntityFrameworkCore;
using Shopping_Core.Models.Order;
using Shopping_Core.Models.OrderItem;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;
using Shopping_Data_Layer.Entities.Order;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class OrderService(
    IGenericRepository<Order> genericRepository,
    IProductService productService,
    IUserService userService,
    IOrderItemService orderItemService
) : IOrderService
{
    #region Constructors

    private IGenericRepository<Order> GenericRepository { get; set; } = genericRepository;
    private IProductService ProductService { get; set; } = productService;
    private IUserService UserService { get; set; } = userService;
    private IOrderItemService OrderItemService { get; set; } = orderItemService;

    #endregion


    public async Task<Order> CreateOrder(long userId)
    {
        var order = new Order()
        {
            IsPay = false,
            UserId = userId,
            PaymentDate = DateTime.Now,
        };

        await GenericRepository.AddEntity(order);
        await GenericRepository.SaveChangesAsync();
        return order;
    }

    public async Task<List<OrderResponse>> GetUserOrders(long userId)
    {
        var user = await UserService.GetUserById(userId);
        return await GenericRepository.GetEntitiesQuery()
            .Where(o => o.UserId == userId && !o.IsDelete)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Select(o => new OrderResponse()
            {
                IsPay = o.IsPay,
                FullName = user.FirstName + " " + user.LastName,
                OrderItemResponse = o.OrderItems.Where(oi=>!oi.IsDelete).Select(oi => new OrderItemResponse()
                {
                    Id = oi.Id,
                    Count = oi.Count,
                    ImageName = oi.Product.ImageName,
                    Price = oi.Product.Price,
                    ProductName = oi.Product.ProductName,
                    ProductId = oi.ProductId
                }).ToList(),
                PaymentDate = o.PaymentDate,
                CreateDate = o.CreateDate,
            }).ToListAsync();
    }

    public async Task<List<OrderResponse>> GetOrders(long userId)
    {
        var user = await UserService.GetUserById(userId);
        return await GenericRepository.GetEntitiesQuery()
            .Include(o=>o.OrderItems)
            .ThenInclude(oi=>oi.Product)
            .Select(order=>new OrderResponse
        {
            Id = order.Id,
            CreateDate = order.CreateDate,
            IsPay = order.IsPay,
            PaymentDate = order.PaymentDate,
            FullName = user.FirstName + " " + user.LastName,
            OrderItemResponse = order.OrderItems.Select(oi=>new OrderItemResponse()
            {
                Id = oi.Id,
                Count = oi.Count,
                ImageName = oi.Product.ImageName,
                Price = oi.Price,
                ProductName = oi.Product.ProductName,
                ProductId = oi.ProductId
            }).ToList()
        }).ToListAsync();
    }

    public async Task<List<OrderItemResponse>> GetOrderItemsByOrderId(long orderId)
    {
        return await OrderItemService.GetOrderItemsResponse(orderId);
    }

    public async Task<int> GetOrderItemsCountByOrderId(long orderId)
    {
        return await OrderItemService.GetOrderItemsResponseCount(orderId);
    }

    public async Task<int> GetOrdersCount()
    {
        return await GenericRepository.GetEntitiesQuery().CountAsync();
    }

    public async Task<Order> GetOpenOrder(long userId)
    {
        var order = await GenericRepository.GetEntitiesQuery()
            .SingleOrDefaultAsync(o => o.UserId == userId && !o.IsPay) ?? await CreateOrder(userId);
        return order;
    }

    public async Task<BasketResponse> GetBasket(long orderId)
    {
        var order = await genericRepository.GetEntitiesQuery()
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .SingleOrDefaultAsync(o => o.Id == orderId);
        return new BasketResponse
        {
            OrderItemResponses = order.OrderItems.Select(orderItem => new OrderItemResponse()
            {
                Id = orderItem.Id,
                Count = orderItem.Count,
                ImageName = $"{CurrentDomain.GetDomain()}{orderItem.Product.ImageName}",
                ProductName = orderItem.Product.ProductName,
                Price = orderItem.Product.Price,
                ProductId = orderItem.ProductId
            }).ToList(),
            SendPay = 4500,
            SumOrderItemsPrice = order.OrderItems.Sum(oi => oi.Price)
        };
    }

    public async Task<OrderResponse> RemoveOrderItem(long orderId, long orderItemId,long userId)
    {
        var user = await UserService.GetUserById(userId);
        var order = await GenericRepository.GetEntitiesQuery().Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
            .SingleOrDefaultAsync(o => o.Id == orderId);
        if (order is null) return null;
        var orderItem = order.OrderItems.SingleOrDefault(oi => oi.Id == orderItemId);
        if (orderItem is null) return null;
        await OrderItemService.RemoveOrderItem(orderItem.Id);
        await GenericRepository.SaveChangesAsync();
        return new OrderResponse()
        {
            IsPay = order.IsPay,
            FullName = user.FirstName + " " + user.LastName,
            OrderItemResponse = order.OrderItems.Where(oi=>!oi.IsDelete).Select(oi => new OrderItemResponse()
            {
                Id = oi.Id,
                Count = oi.Count,
                ImageName = oi.Product.ImageName,
                Price = oi.Product.Price,
                ProductName = oi.Product.ProductName,
                ProductId = oi.ProductId
            }).ToList(),
            PaymentDate = order.PaymentDate,
            CreateDate = order.CreateDate,
        };
    }

    public async Task AddProductToOrder(long userId, long productId, int count)
    {
        var user = await UserService.GetUserById(userId);
        var product = await ProductService.GetProductById(productId);
        if (product is not null && user is not null)
        {
            if (count <= 1)
            {
                count = 1;
            }

            var openOrder = await GetOpenOrder(userId);
            var orderItems = await OrderItemService.GetOrderItems(openOrder.Id);
            var isExistProduct = orderItems.SingleOrDefault(oi => oi.ProductId == productId);
            if (isExistProduct is not null)
            {
                isExistProduct.Count += count;
                await OrderItemService.UpdateOrderItem(isExistProduct);
            }
            else
            {
                var orderItem = new OrderItem()
                {
                    Count = count,
                    OrderId = openOrder.Id,
                    Price = product.Price,
                    ProductId = productId
                };
                await OrderItemService.AddOrderItem(orderItem);
            }
        }
    }
}