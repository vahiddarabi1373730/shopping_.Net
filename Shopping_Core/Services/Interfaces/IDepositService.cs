using Shopping_Data_Layer.Entities.Account;

namespace Shopping_Core.Services.Interfaces;

public interface IDepositService
{
    Task<List<Deposit>> GetAllAsync(long userId);
    Task<int> GetCount(long userId);
    Task<bool> AddDeposit(long userId,decimal amount);
}