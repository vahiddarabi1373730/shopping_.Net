using Shopping_Core.Services.Interfaces;
namespace Shopping_Api.Services;

public class SaveImageService(IWebHostEnvironment webHostEnvironment):ISaveImageService
{
    public async Task<string> SaveImage(IFormFile formFile)
    {
        if (formFile == null || formFile.Length == 0) return null;
        var folderImages = Path.Combine(webHostEnvironment.WebRootPath, "Images");
        if (!Directory.Exists(folderImages))
        {
            Directory.CreateDirectory(folderImages);
        }

        var uniqName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
        var filePath = Path.Combine(folderImages, uniqName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
           await formFile.CopyToAsync(fileStream);
        }
        
        return  "/Images/" + uniqName;
        
    }
}