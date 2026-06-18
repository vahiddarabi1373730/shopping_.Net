using Shopping_Core.Models.ProductGallery;
using Shopping_Data_Layer.Entities.Product;

namespace Shopping_Core.Services.Interfaces;

public interface IProductGalleryService
{
    Task<List<GalleryWithProductResponse>> GetAllProductGallery();
    Task<ProductGallery> AddProductGallery(CreateProductGalleryDto createProductGalleryDto);
}