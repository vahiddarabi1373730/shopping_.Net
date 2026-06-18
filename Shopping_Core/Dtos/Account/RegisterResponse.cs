namespace Shopping_Core.Dtos.Account;

public class RegisterResponse(RegisterStatus registerStatus, string token,UserResponse userResponse)
{
    public RegisterStatus RegisterStatus { get; set; } = registerStatus;
    public string Token { get; set; } = token;
    public UserResponse UserResponse { get; set; } = userResponse;
}