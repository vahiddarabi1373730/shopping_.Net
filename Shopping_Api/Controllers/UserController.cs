using Microsoft.AspNetCore.Mvc;
using Shopping_Core.Dtos.Account;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;

namespace Shopping_Api.Controllers;

public class UserController(IUserService userService):BaseController
{
    #region Properties
    private IUserService UserService { get; set; } = userService;

    #endregion

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return JsonResponse.Success(await UserService.GetAllUsers());
    }
    [HttpPost]
    public async Task<IActionResult> Add(UserRequest request)
    {
        return JsonResponse.Success(await UserService.AddUser(request));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit([FromBody]UserRequest request,long id)
    {
        return JsonResponse.Success(await UserService.Edit(request,id));
    }
}