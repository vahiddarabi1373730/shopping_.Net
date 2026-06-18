using System.Security.Claims;
using Shopping_Core.Dtos.Account;
using Shopping_Data_Layer.Entities.Account;

namespace Shopping_Core.Services.Interfaces;

public interface IUserService:IDisposable
{
    public Task<List<UserResponse>> GetAllUsers();
    public Task<bool> AddUser(UserRequest request);
    public Task<bool> Edit(UserRequest request,long id);
    public Task<RegisterResponse> RegisterUser(User user);
    public Task<LoginResponse> LoginUser(string email,string password,bool checkAdmin=false);
    public Task<User> GetUserByEmailAndPassword(string email,string password);
    public Task<User> GetUserByEmail(string email);
    public Task<User> GetUserById(long id);
    public bool IsEmailExists(string email);
    public Task<UserResponse> ActivateUser(string emailActiveCode);

    public Task<UserResponse> CheckAuth(ClaimsPrincipal user);
    
    public Task<UserResponse> EditUserInfo(EditUserInfoDto editUserInfoDto,long userId);
}