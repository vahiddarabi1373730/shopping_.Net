using Microsoft.AspNetCore.Mvc;
using Shopping_Core.Dtos.Financial;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;
using Shopping_Core.Utilities.Extensions;

namespace Shopping_Api.Controllers;

public class FinancialController(IDepositService depositService,IWithdrawService withdrawService):BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllDeposit()
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            long userId = User.CheckAuthUser();
            var deposits = await depositService.GetAllAsync(userId);
            return JsonResponse.Success(deposits);
        }

        return JsonResponse.UnAuthorized("ابتدا وارد شوید");
    }

    [HttpGet("count")]
    public async Task<IActionResult> GetAllDepositCount()
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            long userId = User.CheckAuthUser();
            var deposits = await depositService.GetCount(userId);
            return JsonResponse.Success(deposits);
        }

        return JsonResponse.UnAuthorized("ابتدا وارد شوید");
    }

    [HttpPost]
    public async Task<IActionResult> AddDeposit([FromBody] DepositRequest depositRequest)
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            long userId = User.CheckAuthUser();
            var deposits = await depositService.AddDeposit(userId,depositRequest.Amount);
            return JsonResponse.Success(deposits);
        }

        return JsonResponse.UnAuthorized("ابتدا وارد شوید");
    }
}