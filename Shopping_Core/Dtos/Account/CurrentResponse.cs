using Shopping_Core.Models.User;
namespace Shopping_Core.Dtos.Account;

public class CurrentResponse( string token,UserWithRoleResponse userResponse,long expireTime,decimal balance)
{
    public string Token { get; set; } = token;
    public long ExpireTime { get; set; } = expireTime;
    public UserWithRoleResponse UserResponse { get; set; } = userResponse;
    public decimal Balance { get; set; } = balance;
}