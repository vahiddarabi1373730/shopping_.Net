using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shopping_Core.Models.Notifications;
using Shopping_Core.Security;
using Shopping_Core.Services.Implementations;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Convertors;
using Shopping_Data_Layer.Repository;

namespace Shopping_Api.Services;

public static class AddServices
{
    public static void AddInjectServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<IPasswordHelper, PasswordHelper>();
        services.AddScoped<IMailSender, SendEmail>();
        services.AddScoped<IViewRenderService, RenderViewToString>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddScoped<ISaveImageService, SaveImageService>();
        services.AddScoped<IProductGalleryService, ProductGalleryService>();
        services.AddScoped<IProductCommentService, ProductCommentService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAccessService, AccessService>();
        services.AddScoped<IDepositService, DepositService>();
        services.AddScoped<IWithdrawService, WithdrawService>();
        services.AddScoped<INotificationService, NotificationService>();
    }

    public static void AddAppSettingsShopping(this IServiceCollection services)
    {
        services.AddSingleton<IConfiguration>(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build());
    }

    public static void AddCorsShopping(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("EnableShoppingCors",
                policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:3000")
                        .WithOrigins("http://localhost:4200")
                        .Build();
                });
        });
    }

    public static IServiceCollection AddSignalRService(this IServiceCollection services)
    {
        services.AddSignalR();
        return services;
    }

    public static void AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken=context.HttpContext.Request.Query["access_token"];
                    var path=context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs/notifications"))
                    {
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;

                }
            };
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("AngularShoppingSecretKeyAngularShoppingSecretKey")),
                ValidIssuer = "https://localhost:3001"
            };
        });
    }

    public static void AddSwaggerGenShopping(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
    }
}