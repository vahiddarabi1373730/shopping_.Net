using Shopping_Core.Models.ProductComment;

namespace Shopping_Core.Services.Interfaces;

public interface IProductCommentService
{
    Task<List<ProductCommentResponse>> GetAllComments(long productId);
    Task<ProductCommentResponse> AddComment(ProductCommentRequest comment,long userId);
}