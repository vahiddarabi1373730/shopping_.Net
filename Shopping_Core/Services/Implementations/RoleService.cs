using Microsoft.EntityFrameworkCore;
using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Access;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class RoleService(IGenericRepository<Role> _genericRepository):IRoleService
{
    public async Task<List<Role>> GetAllRole()
    {
        return await _genericRepository.GetEntitiesQuery().ToListAsync();
    }

    public void Dispose()
    {
        _genericRepository?.Dispose();
    }
}