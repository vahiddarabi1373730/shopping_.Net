using Microsoft.AspNetCore.Mvc;
using Shopping_Core.Models.ProductComment;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;
using Shopping_Core.Utilities.Extensions;

namespace Shopping_Api.Controllers;

public class ProductCommentController(IProductCommentService productCommentService, IProductService productService)
    : BaseController
{
    public IProductCommentService _productCommentService { get; set; } = productCommentService;
    public IProductService _productService { get; set; } = productService;

    [HttpGet("product-comments/{productId}")]
    public async Task<IActionResult> GetProductComments(long productId)
    {
        if (ModelState.IsValid)
        {
            var productCommentsResponse = await _productCommentService.GetAllComments(productId);
            return JsonResponse.Success(productCommentsResponse);
        }

        return JsonResponse.Error("خطا در عملیات");
    }

    [HttpPost("create-comment")]
    public async Task<IActionResult> CreateComment([FromBody] ProductCommentRequest request)
    {
        if (ModelState.IsValid)
        {
            if (!await _productService.IsExistProduct(request.ProductId))
            {
                return JsonResponse.NotFound("محصول یافت نشد");
            }

            if (User.Identity is not null && !User.Identity.IsAuthenticated)
            {
                return JsonResponse.NotFound("ابتدا وارد شوید");
            }

            var user = User.CheckAuthUser();

            var productCommentsResponse = await _productCommentService.AddComment(request, user);
            return JsonResponse.Success(productCommentsResponse);
        }

        return JsonResponse.Error("خطا در عملیات");
    }
}