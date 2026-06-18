using Microsoft.AspNetCore.Mvc;

namespace Shopping_Core.Utilities.Common;

public static class JsonResponse
{
    public static JsonResult Success()
    {
        return new JsonResult(new { Success = true });
    }

    public static JsonResult Success(object returnData)
    {
        return new JsonResult(new { Success = true, Data = returnData });
    }

    public static JsonResult NotFound()
    {
        return new JsonResult(new { Success = false });
    }

    public static JsonResult NotFound(object returnData)
    {
        return new JsonResult(new { Success = false, Data = returnData });
    }

    public static JsonResult Error()
    {
        return new JsonResult(new { Success = false });
    }

    public static JsonResult Error(object returnData)
    {
        return new JsonResult(new { Success = false, Data = returnData });
    }
    
    public static JsonResult UnAuthorized()
    {
        return new JsonResult(new { Success = false });
    }

    public static JsonResult UnAuthorized(object returnData)
    {
        return new JsonResult(new { Success = false, Data = returnData });
    }
    
    public static JsonResult NotAccess()
    {
        return new JsonResult(new { Success = false });
    }

    public static JsonResult NotAccess(object returnData)
    {
        return new JsonResult(new { Success = false, Data = returnData });
    }
}