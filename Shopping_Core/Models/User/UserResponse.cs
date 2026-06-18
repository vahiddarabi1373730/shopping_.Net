using Shopping_Core.Models.UserRole;

namespace Shopping_Core.Models.User;

public class UserWithRoleResponse
{
    public string Email { get; set; }
    public string Address { get; set; }
    public string FullName { get; set; }
    public List<UserRoleResponse> UserRoleResponse { get; set; }
}