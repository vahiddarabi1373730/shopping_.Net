using Shopping_Core.Models.User;
using Shopping_Data_Layer.Entities.Account;

namespace Shopping_Core.Dtos.Account;

public class LoginResponse(LoginStatus loginStatus, string token,Models.User.UserWithRoleResponse userResponse)
{
    public LoginStatus LoginStatus { get; set; } = loginStatus;
    public string Token { get; set; } = token;
    public UserWithRoleResponse UserResponse { get; set; } = userResponse;
}