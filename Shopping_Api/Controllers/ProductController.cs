using Microsoft.AspNetCore.Mvc;
using Shopping_Core.Dtos.Products;
using Shopping_Core.Models.Product;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;

namespace Shopping_Api.Controllers;

public class ProductController(IProductService productService) : BaseController
{
    private IProductService _productService { get; set; } = productService;

    [HttpGet]
    // [PermissionChecker("Admin")]
    public async Task<IActionResult> GetFilterProducts([FromQuery] FilterProductsDto filterProductsDto)
    {
        var responseFilterProductsDto = await _productService.FilterProducts(filterProductsDto);
        return JsonResponse.Success(responseFilterProductsDto.Products);
    }
    
    [HttpGet("count")]
    // [PermissionChecker("Admin")]
    public async Task<IActionResult> GetFilterProductsCount([FromQuery] FilterProductsDto filterProductsDto)
    {
        var count = await _productService.FilterProductsCount(filterProductsDto);
        return JsonResponse.Success(count);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(long id)
    {
        var product = await _productService.GetProductById(id);
        if (product is null)
        {
            return JsonResponse.NotFound("محصول یافت نشد");
        }
        return JsonResponse.Success(product);
    }

    [HttpPost("create-product")]
    public async Task<IActionResult> CreateProduct([FromForm] CrudProductDto crudProductDto)
    {
        var isSuccess =await _productService.AddProducts(crudProductDto);
        if (isSuccess)
        {
            return JsonResponse.Success("عملیات با موفقیت انجام شد.");

        }
        return JsonResponse.Error("خطا در عملیات.");
    }
    
    [HttpGet("related-product/{productId}")]
    public async Task<IActionResult> RelatedProduct(long productId)
    {
        var products =await _productService.GetRelatedProducts(productId);
        if (products is not null)
        {
            return JsonResponse.Success(products);

        }
        return JsonResponse.Error("خطا در عملیات.");
    }
    
    [HttpPut("{productId}")]
    public async Task<IActionResult> Edit([FromForm] CrudProductDto crudProductDto,long productId)
    {
        var isSuccess =await _productService.UpdateProduct(crudProductDto,productId);
        if (isSuccess)
        {
            return JsonResponse.Success("عملیات با موفقیت انجام شد.");
        }
        return JsonResponse.Error("خطا در عملیات.");
    }
    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteProduct(long productId)
    {
        var isSuccess =await _productService.DeleteProduct(productId);
        if (isSuccess)
        {
            return JsonResponse.Success("عملیات با موفقیت انجام شد.");
        }
        return JsonResponse.Error("خطا در عملیات.");
    }
}