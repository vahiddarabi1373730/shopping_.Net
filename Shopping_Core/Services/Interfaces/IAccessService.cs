namespace Shopping_Core.Services.Interfaces;

public interface IAccessService:IDisposable
{
    public Task<bool> CheckAccess(long userId, string roleName);
}