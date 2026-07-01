using Microsoft.EntityFrameworkCore;
using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Account;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class DepositService(IGenericRepository<Deposit> genericRepository,IUserService userService):IDepositService
{
    public IGenericRepository<Deposit> GenericRepository { get; set; } = genericRepository;
    
    public async Task<List<Deposit>> GetAllAsync(long userId)
    {
        return await GenericRepository.GetEntitiesQuery().Where(d => d.UserId == userId).ToListAsync();
    }

    public async Task<int> GetCount(long userId)
    {
        return await GenericRepository.GetEntitiesQuery().Where(d => d.UserId == userId).CountAsync();
    }

    public async Task<bool> AddDeposit(long userId, decimal amount)
    {
        await userService.UpdateBalance(amount, userId);
        var deposit = new Deposit
        {
            UserId = userId,
            IsDelete = false,
            Amount = amount,
            Status = DepositStatus.Success,
        };
        
        GenericRepository.UpdateEntity(deposit);
        return await GenericRepository.SaveChangesAsync();
        
    }
}