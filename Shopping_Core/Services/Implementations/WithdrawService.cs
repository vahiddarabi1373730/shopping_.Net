using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Account;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class WithdrawService(IGenericRepository<Withdraw> genericRepository):IWithdrawService
{
    public IGenericRepository<Withdraw> GenericRepository { get; set; } = genericRepository;
}