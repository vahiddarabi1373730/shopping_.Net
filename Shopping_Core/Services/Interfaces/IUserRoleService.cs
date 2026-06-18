namespace Shopping_Core.Services.Interfaces;

public interface IUserRoleService:IDisposable
{
    public Task<bool> CheckUserAdmin(long userId);
}