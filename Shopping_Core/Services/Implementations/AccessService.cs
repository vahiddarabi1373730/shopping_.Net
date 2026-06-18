using Shopping_Core.Services.Interfaces;

namespace Shopping_Core.Services.Implementations;

public class AccessService(IUserService userService):IAccessService
{
    public async Task<bool> CheckAccess(long userId, string roleName)
    {
        var user =await userService.GetUserById(userId);
        return user.UserRoles.Any(ur=>ur.Role.Name==roleName);
    }

    public void Dispose()
    {
        userService.Dispose();
    }
}