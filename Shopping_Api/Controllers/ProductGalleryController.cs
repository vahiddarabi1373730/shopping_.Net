using Microsoft.AspNetCore.Mvc;
using Shopping_Core.Models.ProductGallery;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;

namespace Shopping_Api.Controllers;

public class ProductGalleryController(IProductGalleryService productGalleryService):BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllProductGallery()
    {
        var productGalleries = await productGalleryService.GetAllProductGallery();
        return JsonResponse.Success(productGalleries);
    }
    
    [HttpPost("create-product-gallery")]
    public async Task<IActionResult> CreateProduct([FromForm] CreateProductGalleryDto createProductGalleryDto)
    {
        var productGallery =await productGalleryService.AddProductGallery(createProductGalleryDto);
        if (productGallery is not null)
        {
            return JsonResponse.Success("عملیات با موفقیت انجام شد.");

        }
        return JsonResponse.Error("خطا در عملیات.");
    }
}