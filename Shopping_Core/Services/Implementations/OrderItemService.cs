using Microsoft.EntityFrameworkCore;
using Shopping_Core.Models.Order;
using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Order;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class OrderItemService(IGenericRepository<OrderItem> genericRepository):IOrderItemService
{
    public IGenericRepository<OrderItem> _genericRepository { get; set; } = genericRepository;
    
    
    public async Task AddOrderItem(OrderItem orderItem)
    {
        await _genericRepository.AddEntity(orderItem);
        await _genericRepository.SaveChangesAsync();
    }

    
    public async Task<bool> RemoveOrderItem(long orderItemId)
    {
        await _genericRepository.DeleteEntity(orderItemId);
        return await _genericRepository.SaveChangesAsync();
    }

    public async Task<List<OrderItem>> GetOrderItems(long orderId)
    {
        return await _genericRepository.GetEntitiesQuery().Where(oi => oi.OrderId == orderId).ToListAsync();
    }


    public async Task<bool> UpdateOrderItem(OrderItem orderItem)
    {
         _genericRepository.UpdateEntity(orderItem);
         return await _genericRepository.SaveChangesAsync();
    }
}