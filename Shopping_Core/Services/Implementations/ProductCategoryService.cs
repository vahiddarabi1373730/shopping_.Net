using Microsoft.EntityFrameworkCore;
using Shopping_Core.Dtos.Paging;
using Shopping_Core.Dtos.ProductCategory;
using Shopping_Core.Models.Notifications;
using Shopping_Core.Models.ProductCategory;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Extensions;
using Shopping_Data_Layer.Entities.Product;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class ProductCategoryService(IGenericRepository<ProductCategory> genericRepository,INotificationService notificationService):IProductCategoryService
{
    public async Task<List<ProductCategoryResponse>> ProductCategories(ProductCategoryRequest request)
    {
        var query = genericRepository.GetEntitiesQuery().Where(pc => !pc.IsDelete);
            
        if (request.Title is  not null)
        {
            query=query.Where(c=>c.Title.Trim().Contains(request.Title.Trim()));
        }

        if (!string.IsNullOrEmpty(request.UrlTitle))
        {
            query=query.Where(pc=>pc.UrlTitle.Trim().Contains(request.UrlTitle.Trim()));
        }

        if (request.ParentId.HasValue)
        {
            query=query.Where(pc=>pc.ParentId==request.ParentId.Value);
        }
        
        query=query.OrderByDescending(pc => pc.CreateDate);
        var basePaging = Pager.BuildBasePaging(query, request.TakeEntity, request.ActivePage);
        query = query.Paging(basePaging);
        var result= await query.Select(pc=>new ProductCategoryResponse
        {
            ParentId = pc.ParentId,
            Title = pc.Title,
            UrlTitle = pc.UrlTitle,
            Id = pc.Id
        }).ToListAsync();
        return result;
    }

    public async Task<int> ProductCategoriesCount()
    {
        return await genericRepository.GetEntitiesQuery().Where(pc => !pc.IsDelete).OrderByDescending(pc=>pc.CreateDate).CountAsync();
    }

    public async Task<ProductCategory> GetProductCategoryById(long id)
    {
        return await genericRepository.GetEntityById(id);
    }

    public async Task<bool> CreateProductCategory(CreateProductCategoryRequest request)
    {
        var entity = new ProductCategory
        {
            IsDelete = false,
            ParentId = null,
            UrlTitle = request.UrlTitle,
            Title = request.Title,
        };
        await genericRepository.AddEntity(entity);
        var result= await genericRepository.SaveChangesAsync();
        if (result)
        {
            var response = new ProductCategoryResponse
            {
                ParentId = entity.ParentId,
                Title = entity.Title,
                UrlTitle = entity.UrlTitle,
                Id = entity.Id
            };
            await notificationService.CreateProductCategory(response);
        }
        return result;
    }

    public async Task<bool> EditProductCategory(CreateProductCategoryRequest request, long id)
    {
        var entity =await genericRepository.GetEntityById(id);
        entity.UrlTitle = request.UrlTitle;
        entity.Title = request.Title;
        genericRepository.UpdateEntity(entity);
        var success= await genericRepository.SaveChangesAsync();
        if (success)
        {
            var response = new ProductCategoryResponse
            {
                ParentId = entity.ParentId,
                Title = entity.Title,
                UrlTitle = entity.UrlTitle,
                Id = entity.Id
            };
            await notificationService.UpdateProductCategory(response);
        }

        return success;
    }
    

    public async Task<bool> DeleteProductCategory(long id)
    {
        await genericRepository.DeleteEntity(id);
        return await genericRepository.SaveChangesAsync();
    }
}