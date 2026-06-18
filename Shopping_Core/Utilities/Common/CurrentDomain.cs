using Microsoft.AspNetCore.Http;

namespace Shopping_Core.Utilities.Common;

public static class CurrentDomain
{
    public static IHttpContextAccessor  HttpContextAccessor { get; set; }
    public static string GetDomain()
    {
        if (HttpContextAccessor?.HttpContext == null) return string.Empty;
        var request=HttpContextAccessor.HttpContext.Request;
        return $"{request.Scheme}://{request.Host.Value}";
    }
}