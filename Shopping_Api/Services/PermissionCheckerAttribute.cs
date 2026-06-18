using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;
using Shopping_Core.Utilities.Extensions;

namespace Shopping_Api.Services;

public class PermissionCheckerAttribute(string roleName) : AuthorizeAttribute, IAuthorizationFilter
{
    public string RoleName { get; set; } = roleName;

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User.Identity is not null && context.HttpContext.User.Identity.IsAuthenticated)
        {
            long userId = context.HttpContext.User.CheckAuthUser();
            var accessService = context.HttpContext.RequestServices.GetRequiredService<IAccessService>();
            var isAccess =  accessService.CheckAccess(userId, RoleName).Result;
            if (!isAccess)
            {
                context.Result = JsonResponse.NotAccess("شما دسترسی ندارید");
                return;
            }
            
            context.Result = JsonResponse.Success("دسترسی دارید");
            return;
        }
        else
        {
            context.Result = JsonResponse.UnAuthorized("ابتدا وارد شوید");
            return;
        }
    }
}