using Microsoft.EntityFrameworkCore;
using Shopping_Core.Dtos.Paging;
using Shopping_Core.Dtos.Products;
using Shopping_Core.Models.Product;
using Shopping_Core.Models.ProductGallery;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;
using Shopping_Core.Utilities.Extensions;
using Shopping_Data_Layer.Entities.Product;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class ProductService(
    IGenericRepository<Product> genericRepository,
    ISaveImageService saveImageService,
    IGenericRepository<ProductSelectedCategory> genericRepositorySelectedCategory) : IProductService
{
    private IGenericRepository<Product> _genericRepository { get; } = genericRepository;

    private IGenericRepository<ProductSelectedCategory> _genericRepositorySelectedCategory { get; } =
        genericRepositorySelectedCategory;

    private ISaveImageService _saveImageService { get; } = saveImageService;


    public void Dispose()
    {
        _genericRepository.Dispose();
    }

    public async Task<bool> AddProducts(CrudProductDto crudProductDto)
    {
        Product product = new Product
        {
            Price = crudProductDto.Price,
            IsDelete = crudProductDto.IsDelete,
            Description = crudProductDto.Description,
            ShortDescription = crudProductDto.ShortDescription,
            ProductName = crudProductDto.ProductName,
            IsSpecial = crudProductDto.IsSpecial,
            IsExists = crudProductDto.IsExists,
            CreateDate = DateTime.Parse(crudProductDto.CreateDate)
        };

        if (crudProductDto.ImageFile is not null)
        {
            product.ImageName = await _saveImageService.SaveImage(crudProductDto.ImageFile);
        }

        await _genericRepository.AddEntity(product,true);
        return await _genericRepository.SaveChangesAsync();
    }

    public async Task<List<ProductResponse>> GetRelatedProducts(long productId)
    {
        var product = await _genericRepository.GetEntityById(productId);
        if (product is null) return null;
        
        //برو لیست Id تمام دسته بندی هایی که این محصول در آن وجود دارند را بیار
        var selectedCategoryIds = await _genericRepositorySelectedCategory.GetEntitiesQuery()
            .Where(psc => psc.ProductId == productId)
            .Select(psc => psc.ProductCategoryId).ToListAsync();
        
        //اگر لیست خالی بود یه لیست خالی برگردان
        if (!selectedCategoryIds.Any())
        {
            return new List<ProductResponse>();
        }

        //ابتدا ProductGalleries را بیار سپس چک کن که لیستی که میخواهی برگردانی شامل همین محصول نباشد سپس در لیست ProductSelectedCategories اگر هر رکوردی ProductCategoryId داخل selectedCategoryIds بود آن رکورد را برگردان و در نهایت 6 رکورد را به من بده
        var relatedProduct = await _genericRepository.GetEntitiesQuery()
            .Include(p => p.ProductGalleries)
            .Where(pr =>
                pr.Id != productId &&
                pr.ProductSelectedCategories.Any(psc => selectedCategoryIds.Contains(psc.ProductCategoryId)))
            .Take(6).ToListAsync();

       
        return relatedProduct.Select(p => new ProductResponse
        {
            Price = p.Price,
            Description = p.Description,
            ImageName = p.ImageName,
            ProductName = p.ProductName,
            IsExists = p.IsExists,
            IsSpecial = p.IsSpecial,
            ShortDescription = p.ShortDescription,
            Images = p.ProductGalleries.Select(pg => new GalleryImageResponse
            {
                ImageName = pg.ImageName,
                ProductId = pg.ProductId
            }).ToList(),
        }).ToList();
    }

    public async Task<bool> IsExistProduct(long productId)
    {
        return await _genericRepository.GetEntitiesQuery().AnyAsync(c => c.Id == productId);
    }

    public async Task<ProductResponse> GetProductById(long id)
    {
        var product = await _genericRepository.GetEntitiesQuery()
            .Include(p=>p.ProductGalleries).SingleAsync(p=>p.Id==id);
        var res = new ProductResponse
        {
            Id = product.Id,
            Price = product.Price,
            Description = product.Description,
            ImageName = product.ImageName,
            ProductName = product.ProductName,
            IsExists = product.IsExists,
            IsSpecial = product.IsSpecial,
            ShortDescription = product.ShortDescription,
            CreateDate = product.CreateDate,
            Images =product.ProductGalleries.Count!=0 ? product.ProductGalleries.Select(pg=>new  GalleryImageResponse
            {
                ImageName = pg.ImageName,ProductId = pg.ProductId
            }) .ToList():[]
        };
        return res;
    }

    public async Task<FilterProductsDto> FilterProducts(FilterProductsDto filterProductsDto)
    {
        var productQuery = FilterProductsQuery(filterProductsDto);
        var count = (int)Math.Ceiling(productQuery.Count() / (decimal)filterProductsDto.TakeEntity);
        var basePaging = Pager.Build(count, filterProductsDto.TakeEntity, filterProductsDto.ActivePage);
        var products = await productQuery.Paging(basePaging).Include(p => p.ProductGalleries).ToListAsync();
        return filterProductsDto.SetProducts(products).SetPaging(basePaging);
    }
    
    public IQueryable<Product> FilterProductsQuery(FilterProductsDto filterProductsDto)
    {
        var productQuery = _genericRepository
            .GetEntitiesQuery()
            .Where(p=>p.IsDelete!=true)
            .Include(p => p.ProductGalleries)
            .OrderByDescending(p=>p.CreateDate)
            .AsQueryable();
        if (!string.IsNullOrEmpty(filterProductsDto.Title))
        {
            productQuery = productQuery.Where(p => p.Description.Contains(filterProductsDto.Title));
        }

        if (filterProductsDto.ProductOrderBy.HasValue)
        {
            switch (filterProductsDto.ProductOrderBy.Value)
            {
                case ProductOrderBy.PriceAscending:
                    productQuery = productQuery.OrderBy(p => p.Price);
                    break;
                case ProductOrderBy.PriceDescending:
                    productQuery = productQuery.OrderByDescending(p => p.Price);
                    break;
            }
        }

        if (filterProductsDto.CategoryIds is not null && filterProductsDto.CategoryIds.Any())
        {
            productQuery = productQuery.SelectMany(p =>
                p.ProductSelectedCategories
                    .Where(pc => filterProductsDto.CategoryIds.Contains(pc.ProductCategoryId))
                    .Select(psc => psc.Product));
        }

        if (filterProductsDto.StartPrice.HasValue)
        {
            productQuery = productQuery.Where(p => p.Price >= filterProductsDto.StartPrice);
        }

        if (filterProductsDto.EndPrice.HasValue)
        {
            productQuery = productQuery.Where(p => p.Price <= filterProductsDto.EndPrice);
        }

        return productQuery;
    }


    public async Task<int> FilterProductsCount(FilterProductsDto filterProductsDto)
    {
        var productQuery = FilterProductsQuery(filterProductsDto);
        return  productQuery.Count();
    }


    public async Task<bool> UpdateProduct(CrudProductDto crudProductDto,long productId)
    {
        var product = await _genericRepository.GetEntityById(productId);

        if (product is null) return false;
        product.IsSpecial=crudProductDto.IsSpecial;
        product.ProductName=crudProductDto.ProductName;
        product.ShortDescription = crudProductDto.ShortDescription;
        product.Description = crudProductDto.Description;
        product.Price=crudProductDto.Price;
        product.IsExists=crudProductDto.IsExists;
        product.CreateDate = DateTime.Parse(crudProductDto.CreateDate);

        if (crudProductDto.ImageFile is not null)
        {
            product.ImageName = await _saveImageService.SaveImage(crudProductDto.ImageFile);
        }
        _genericRepository.UpdateEntity(product,true);
        return await _genericRepository.SaveChangesAsync();

    }

    public async Task<bool> DeleteProduct(long productId)
    {
        await _genericRepository.DeleteEntity(productId);
        return await _genericRepository.SaveChangesAsync();
    }
}