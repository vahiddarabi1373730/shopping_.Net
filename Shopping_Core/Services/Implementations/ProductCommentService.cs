using Microsoft.EntityFrameworkCore;
using Shopping_Core.Models.ProductComment;
using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Product;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class ProductCommentService(IGenericRepository<ProductComment> _genericRepository):IProductCommentService
{
    public async Task<List<ProductCommentResponse>> GetAllComments(long productId)
    {
        return  await _genericRepository.GetEntitiesQuery()
            .Where(c => c.ProductId == productId && c.IsDelete==false)
            .OrderBy(c=>c.CreateDate)
            .Select(c=>new ProductCommentResponse
            {
                ProductId = productId,
                CreateDate = c.CreateDate,
                Text = c.Text,
                UserId =c.UserId
            }).ToListAsync();
    }

    public async Task<ProductCommentResponse> AddComment(ProductCommentRequest comment,long userId)
    {
        
        ProductComment productComment = new ProductComment
        {
            ProductId = comment.ProductId,
            Text = comment.Text,
            UserId = userId,
        };
        
        await _genericRepository.AddEntity(productComment);
        await _genericRepository.SaveChangesAsync();

        return new ProductCommentResponse
        {
            ProductId = productComment.ProductId,
            CreateDate = productComment.CreateDate,
            Text = productComment.Text,
            UserId = productComment.UserId
        };

    }
}