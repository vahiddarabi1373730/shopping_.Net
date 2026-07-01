using Microsoft.AspNetCore.Mvc;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;

namespace Shopping_Api.Controllers;

public class Linq(ILinqService linqService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetLinq()
    {
        var response=await linqService.GetAll();
        return JsonResponse.Success(response);
    }
}