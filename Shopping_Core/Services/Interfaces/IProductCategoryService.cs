using Shopping_Core.Dtos.ProductCategory;
using Shopping_Core.Models.ProductCategory;
using Shopping_Data_Layer.Entities.Product;

namespace Shopping_Core.Services.Interfaces;

public interface IProductCategoryService
{
    Task<List<ProductCategoryResponse>> ProductCategories(ProductCategoryRequest request);
    Task<int> ProductCategoriesCount();
    Task<ProductCategory> GetProductCategoryById(long id);
    Task<bool> CreateProductCategory(CreateProductCategoryRequest request);
    Task<bool> EditProductCategory(CreateProductCategoryRequest request,long id);
    Task<bool> DeleteProductCategory(long id);

}