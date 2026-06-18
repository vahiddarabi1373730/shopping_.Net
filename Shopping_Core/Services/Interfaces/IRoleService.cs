using Shopping_Data_Layer.Entities.Access;

namespace Shopping_Core.Services.Interfaces;

public interface IRoleService:IDisposable
{
    public Task<List<Role>> GetAllRole();
}