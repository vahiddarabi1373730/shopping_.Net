using Microsoft.AspNetCore.Mvc;
using Shopping_Core.Dtos.ProductCategory;
using Shopping_Core.Models.ProductCategory;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;

namespace Shopping_Api.Controllers;

public class ProductCategoryController(IProductCategoryService productCategoryService):BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllProductCategory([FromQuery]ProductCategoryRequest request)
    {
        var productCategories = await productCategoryService.ProductCategories(request);
        return JsonResponse.Success(productCategories);
    }
    [HttpGet("count")]
    public async Task<IActionResult> GetAllProductCategoryCount()
    {
        var count = await productCategoryService.ProductCategoriesCount();
        return JsonResponse.Success(count);
    }
    
    [HttpGet("products/{id}")]
    public async Task<IActionResult> GetProductById(long id)
    {
        var productCategory = await productCategoryService.GetProductCategoryById(id);
        return JsonResponse.Success(productCategory);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]  CreateProductCategoryRequest request)
    {
        var productCategories = await productCategoryService.CreateProductCategory(request);
        return JsonResponse.Success(productCategories);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit([FromBody]  CreateProductCategoryRequest request,long id)
    {
        var productCategories = await productCategoryService.EditProductCategory(request,id);
        return JsonResponse.Success(productCategories);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var isSuccess = await productCategoryService.DeleteProductCategory(id);
        return JsonResponse.Success(isSuccess);
    }
}