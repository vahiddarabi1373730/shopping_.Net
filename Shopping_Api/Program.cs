using System.Text;
using Shopping_Api.Hubs;
using Shopping_Api.Services;
using Shopping_Core.Utilities.Common;
using Shopping_Core.Utilities.Extensions;

Console.OutputEncoding = Encoding.UTF8;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGenShopping();
builder.Services.AddControllers();
builder.Services.AddConnectionStrings(builder.Configuration);
builder.Services.AddInjectServices();
builder.Services.AddCorsShopping();
builder.Services.AddJwtAuthentication();
builder.Services.AddAppSettingsShopping();
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalRService();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

CurrentDomain.HttpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();

await app.SeedDataAsync();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("EnableShoppingCors");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<NotificationHub>("/hubs/notifications");
app.Run();