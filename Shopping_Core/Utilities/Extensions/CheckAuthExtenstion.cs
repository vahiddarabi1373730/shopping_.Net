using System.Security.Claims;

namespace Shopping_Core.Utilities.Extensions;

public static class CheckAuthExtenstion
{
    public static long CheckAuthUser(this ClaimsPrincipal claimsPrincipal)
    {
        var id = claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
        return Int64.Parse(id!);

    }
}