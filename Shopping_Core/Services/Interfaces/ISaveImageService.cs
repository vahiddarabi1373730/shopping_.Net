using Microsoft.AspNetCore.Http;

namespace Shopping_Core.Services.Interfaces;

public interface ISaveImageService
{
    public Task<string> SaveImage(IFormFile formFile);
}