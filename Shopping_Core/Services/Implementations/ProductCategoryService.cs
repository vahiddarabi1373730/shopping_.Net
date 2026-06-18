using Microsoft.EntityFrameworkCore;
using Shopping_Core.Dtos.ProductCategory;
using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Product;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class ProductCategoryService(IGenericRepository<ProductCategory> _genericRepository):IProductCategoryService
{
    public async Task<List<ProductCategory>> ProductCategories()
    {
        return await _genericRepository.GetEntitiesQuery().Where(pc => !pc.IsDelete).OrderByDescending(pc=>pc.CreateDate).ToListAsync();
    }

    public async Task<ProductCategory> GetProductCategoryById(long id)
    {
        return await _genericRepository.GetEntityById(id);
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
        await _genericRepository.AddEntity(entity);
        return await _genericRepository.SaveChangesAsync();
    }

    public async Task<bool> EditProductCategory(CreateProductCategoryRequest request, long id)
    {
        var entity =await _genericRepository.GetEntityById(id);
        entity.UrlTitle = request.UrlTitle;
        entity.Title = request.Title;
        _genericRepository.UpdateEntity(entity);
        return await _genericRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteProductCategory(long id)
    {
        await _genericRepository.DeleteEntity(id);
        return await _genericRepository.SaveChangesAsync();
    }
}