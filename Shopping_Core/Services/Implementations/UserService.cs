using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AngularEshop.Core.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shopping_Core.Dtos.Account;
using Shopping_Core.Models.User;
using Shopping_Core.Models.UserRole;
using Shopping_Core.Security;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Convertors;
using Shopping_Core.Utilities.Extensions;
using Shopping_Data_Layer.Entities.Account;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class UserService(
    IGenericRepository<User> genericRepository,
    IPasswordHelper passwordHelper,
    IViewRenderService viewRenderService,
    IUserRoleService  userRoleService,
    IMailSender mailSender) : IUserService
{
    #region Properties

    private IGenericRepository<User> _genericRepository { get; } = genericRepository;
    private IPasswordHelper _passwordHelper { get; } = passwordHelper;
    private IMailSender _mailSender { get; } = mailSender;
    private IViewRenderService _viewRenderService { get; } = viewRenderService;
    private IUserRoleService _userRoleService { get; } = userRoleService;

    #endregion


    #region Methods

    public async Task<List<UserResponse>> GetAllUsers()
    {
        return await _genericRepository.GetEntitiesQuery().Select(user=>new UserResponse()
        {
            Address = user.Address,
            Email =  user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
        }).ToListAsync();
    }

    public async Task<bool> AddUser(UserRequest request)
    {
        var user= new User
        {
            Address = request.Address,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password,
            
        };
        await _genericRepository.AddEntity(user);
        return await _genericRepository.SaveChangesAsync();
    }

    public async Task<bool> Edit(UserRequest request,long id)
    {
        var user = await _genericRepository.GetEntityById(id);
        user.Address=request.Address;
        user.Email = request.Email;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        
        
        
        _genericRepository.UpdateEntity(user);
        return await _genericRepository.SaveChangesAsync();
    }

    public async Task<RegisterResponse> RegisterUser(User userbody)
    {
        if (IsEmailExists(userbody.Email))
        {
            return new RegisterResponse(RegisterStatus.EmailExists, null, null);
        }

        User user = new User
        {
            Address = userbody.Address.SanitizeText(),
            Email = userbody.Email.SanitizeText(),
            FirstName = userbody.FirstName.SanitizeText(),
            LastName = userbody.LastName.SanitizeText(),
            Password = _passwordHelper.EncodePasswordMd5(userbody.Password),
            EmailActiveCode = Guid.NewGuid().ToString(),
        };
        await _genericRepository.AddEntity(user);
        await _genericRepository.SaveChangesAsync();
        UserResponse userResponse = new UserResponse
        {
            Address = userbody.Address.SanitizeText(),
            Email = userbody.Email.SanitizeText(),
            FirstName = userbody.FirstName.SanitizeText(),
            LastName = userbody.LastName.SanitizeText(),
        };
        var userAfterSave =await GetUserByEmail(userResponse.Email);
        var token = GenerateToken(userResponse.Email, userAfterSave.Id);
        var body = await _viewRenderService.RenderToStringAsync("Email/Activated_Account", null);
        _mailSender.Send("db.vahid1373@gmail.com","فعال سازی",body);
        return new RegisterResponse(RegisterStatus.IsSuccess, token, userResponse);

    }

    public async Task<LoginResponse> LoginUser(string email, string password,bool checkAdmin=false)
    {
        var encodePassword = _passwordHelper.EncodePasswordMd5(password);
        var user =await GetUserByEmailAndPassword(email, encodePassword);
        if (user is null)
        {
            return new LoginResponse(LoginStatus.InCorrectData,"",null);
        }
        if (!user.IsActivated)
        {
            return new LoginResponse(LoginStatus.IsDeActiveUser,"",null);
        }

        if (checkAdmin)
        {
            var isAdmin = await _userRoleService.CheckUserAdmin(user.Id);
            if (!isAdmin)
            {
                return new LoginResponse(LoginStatus.NotAdmin,"",null);
            }
        }


        var userWithRoleResponse=new UserWithRoleResponse()
        {
            Address = user.Address,
            Email = user.Email,
            FullName = $"{user.FirstName}-{user.LastName}",
            UserRoleResponse = user.UserRoles.Select(userRole=>new UserRoleResponse()
            {
                Name = userRole.Role.Name,
                Title = userRole.Role.Title
            }).ToList()
            
        };
        var token = GenerateToken(email, user.Id);
        return new LoginResponse(LoginStatus.IsSuccess,token,userWithRoleResponse);
    }

    private string GenerateToken(string email,long id)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AngularShoppingSecretKeyAngularShoppingSecretKey"));
        var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenOptions = new JwtSecurityToken(issuer: "https://localhost:3001", claims: new List<Claim>
        {
            new Claim(ClaimTypes.Name,email),
            new Claim(ClaimTypes.NameIdentifier,id.ToString())
        },expires: DateTime.Now.AddDays(30),signingCredentials:signInCredentials);

        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return token;
    }
    public async Task<User> GetUserByEmailAndPassword(string email,string encodePassword)
    {
        return await  _genericRepository.GetEntitiesQuery().Include(u=>u.UserRoles).ThenInclude(ur=>ur.Role)
            .SingleOrDefaultAsync(user => user.Email == email.ToLower().Trim() && user.Password == encodePassword);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _genericRepository.GetEntitiesQuery().FirstOrDefaultAsync(user=>user.Email==email.ToLower().Trim());
    }

    public async Task<User> GetUserById(long id)
    {
        return await _genericRepository.GetEntitiesQuery().Include(u=>u.UserRoles).ThenInclude(ur=>ur.Role).FirstOrDefaultAsync(user=>user.Id==id);
    }

    public bool IsEmailExists(string email)
    {
        return _genericRepository.GetEntitiesQuery().Any(user => user.Email == email.ToLower().Trim());
        
    }

    public async Task<UserResponse> ActivateUser(string emailActiveCode)
    {
        var user=await _genericRepository.GetEntitiesQuery().FirstOrDefaultAsync(user=>user.EmailActiveCode==emailActiveCode);
        user.IsActivated = true;
        _genericRepository.UpdateEntity(user);
        await _genericRepository.SaveChangesAsync();
        return new UserResponse
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
        };

    }

    public async Task<UserResponse> CheckAuth(ClaimsPrincipal claimsPrincipal)
    {

        var id = claimsPrincipal.CheckAuthUser();
        var user = await GetUserById(id);
        return new UserResponse
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
        };
    }

    public async Task<UserResponse> EditUserInfo(EditUserInfoDto editUserInfoDto,long userId)
    {
        var user = await _genericRepository.GetEntityById(userId);
        if (user is null) return null;
        user.FirstName = editUserInfoDto.FirstName;
        user.LastName = editUserInfoDto.LastName;
        user.Address = editUserInfoDto.Address;
        _genericRepository.UpdateEntity(user);
        await _genericRepository.SaveChangesAsync();
        return new UserResponse()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
        };
    }

    #endregion


    #region Dispose

    public void Dispose()
    {
        _genericRepository?.Dispose();
    }

    #endregion
}