using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Shopping_Api.Services;
using Shopping_Core.Dtos.Account;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;
using Shopping_Core.Utilities.Extensions;
using Shopping_Data_Layer.Entities.Account;

namespace Shopping_Api.Controllers;

public class AccountController(IUserService userService) : BaseController
{
    private IUserService _userService { get; set; } = userService;

    #region Login

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var loginResponse = await _userService.LoginUser(loginDto.Email, loginDto.Password);

        switch (loginResponse.LoginStatus)
        {
            case LoginStatus.InCorrectData:
                return JsonResponse.NotFound("کاربر یافت نشد");
            case LoginStatus.IsDeActiveUser:
                return JsonResponse.Error("حساب کاربری فعال نیست");
            default: 
                return JsonResponse.Success(new
                {
                    token = loginResponse.Token,
                    fullName=loginResponse.UserResponse.FullName,
                    role=loginResponse.UserResponse.UserRoleResponse,
                    expireTime = DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds(),
                });
        }
    }
    
    [HttpPost("login-admin")]
    public async Task<IActionResult> LoginAdmin([FromBody] LoginDto loginDto)
    {
        var loginResponse = await _userService.LoginUser(loginDto.Email, loginDto.Password,true);

        switch (loginResponse.LoginStatus)
        {
            case LoginStatus.InCorrectData:
                return JsonResponse.NotFound("کاربر یافت نشد");
            case LoginStatus.IsDeActiveUser:
                return JsonResponse.Error("حساب کاربری فعال نیست");
            case LoginStatus.NotAdmin:
                return JsonResponse.Error("دسترسی ندارید");
            default: 
                return JsonResponse.Success(new
                {
                    token = loginResponse.Token,
                    fullName=loginResponse.UserResponse.FullName,
                    role=loginResponse.UserResponse.UserRoleResponse,
                    expireTime = 30,
                });
        }
    }

    #endregion

    #region Register

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var registerResponse = await _userService.RegisterUser(new User
        {
            Address = registerDto.Address,
            Email = registerDto.Email,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Password = registerDto.Password,
        });

        switch (registerResponse.RegisterStatus)
        {
            case RegisterStatus.EmailExists:
                var error = new ErrorResponse
                {
                    IsSuccess = false,
                    Message = "ایمیل وارد شده از قبل وجود دارد"
                };
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            default: 
                return JsonResponse.Success(new
                {
                    token=registerResponse.Token,
                    userResponse=registerResponse.UserResponse,
                    expireTime = 30
                });
                
                
        }
       
    }

    #endregion

    #region LogOut

    [HttpGet("logOut")]
    public async Task<IActionResult> LogOut()
    {
        if (User?.Identity?.IsAuthenticated == true)
        {
            await HttpContext.SignOutAsync();
            return JsonResponse.Success();
        }

        return JsonResponse.Error();
    }

    #endregion

    #region CheckAuth

    [HttpGet("checkAuth")]
    public async Task<IActionResult> CheckAuth()
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            var userResponse = await _userService.CheckAuth(User);
            return JsonResponse.Success(new
            {
                userResponse = userResponse
            });

        }
        return JsonResponse.Error("کاربر یافت نشد");
    }

    #endregion

    #region Activate_Account

    [HttpPost("activate_account")]
    public async Task<IActionResult> ActiveAccount(string emailActiveCode)
    {
        var response = await _userService.ActivateUser(emailActiveCode);
        if (response is not null) 
        {
            return  JsonResponse.Success(response);
        }
        
        return  JsonResponse.Error("کاربر یافت نشد.");
    }

    #endregion

    #region EditUserInfo

    [HttpPut("editUserInfo")]
    public async Task<IActionResult> EditUserInfo([FromBody] EditUserInfoDto editUserInfoDto)
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            long id = User.CheckAuthUser();
            var response = await _userService.EditUserInfo(editUserInfoDto, id);
            if (response is null)
            {
                return JsonResponse.NotFound("کاربر یافت نشد");
            }
            return JsonResponse.Success(response);
            
        }

        return JsonResponse.UnAuthorized("ابتدا وارد شوید.");
    }

    #endregion

    #region  Current

    [HttpGet]
    public async Task<IActionResult> Current()
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            var userId =  User.CheckAuthUser();
            var currentResponse = await _userService.CurrentUser(userId);
            return JsonResponse.Success(currentResponse);
        }
        return JsonResponse.UnAuthorized("ابتدا وارد شوید.");
    }

    #endregion
}