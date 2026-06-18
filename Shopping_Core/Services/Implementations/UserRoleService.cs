using Microsoft.EntityFrameworkCore;
using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Access;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class UserRoleService(IGenericRepository<UserRole> _genericRepository):IUserRoleService
{
    public async Task<bool> CheckUserAdmin(long userId)
    {
        return await _genericRepository.GetEntitiesQuery()
            .Include(ur => ur.Role)
            .AnyAsync(userRole => userRole.UserId == userId && userRole.Role.Name =="Admin");
    }

    public void Dispose()
    {
        _genericRepository?.Dispose();
    }
}