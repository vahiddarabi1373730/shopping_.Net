using Shopping_Core.Dtos.Products;
using Shopping_Core.Models.Product;
using Shopping_Data_Layer.Entities.Product;

namespace Shopping_Core.Services.Interfaces;

public interface IProductService:IDisposable
{
    Task<bool> AddProducts(CrudProductDto crudProductDto);
    Task<List<ProductResponse>> GetRelatedProducts(long productId); 
    Task<bool> IsExistProduct(long productId);
    Task<Product> GetProductById(long id);
    
    Task<FilterProductsDto> FilterProducts(FilterProductsDto filterProductsDto);
    Task<int> FilterProductsCount(FilterProductsDto filterProductsDto);
    Task<bool> UpdateProduct(CrudProductDto crudProductDto,long productId);
}