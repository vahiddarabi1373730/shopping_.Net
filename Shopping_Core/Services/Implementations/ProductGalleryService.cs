using Microsoft.EntityFrameworkCore;
using Shopping_Core.Models.ProductGallery;
using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Product;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class ProductGalleryService(IGenericRepository<ProductGallery> _genericRepository,ISaveImageService saveImageService):IProductGalleryService
{
    private ISaveImageService _saveImageService { get; } = saveImageService;
    public async Task<List<GalleryWithProductResponse>> GetAllProductGallery()
    {
        return await _genericRepository.GetEntitiesQuery().Where(pg => !pg.IsDelete).Select(pg => new GalleryWithProductResponse()
        {
            Price = pg.Product.Price,
            Description = pg.Product.Description,
            ProductName = pg.Product.ProductName,
            ImageFile = pg.ImageName
        }).ToListAsync();
    }

    public async Task<ProductGallery> AddProductGallery(CreateProductGalleryDto createProductGalleryDto)
    {
        if (!createProductGalleryDto.ProductId.HasValue)
        {
            throw new Exception("محصول انتخاب نشده است");
        }
        var productGallery = new ProductGallery
        {
            IsDelete = createProductGalleryDto.IsDelete,
            ProductId = createProductGalleryDto.ProductId.Value,
        };
        
        if (createProductGalleryDto.ImageFile is not null)
        {
            productGallery.ImageName = await _saveImageService.SaveImage(createProductGalleryDto.ImageFile);
        }
        await _genericRepository.AddEntity(productGallery);
        await _genericRepository.SaveChangesAsync();
        return productGallery;
    }
}