using Shopping_Core.Dtos.Paging;
using Shopping_Core.Models;
using Shopping_Core.Models.Product;
using Shopping_Core.Models.ProductGallery;
using Shopping_Data_Layer.Entities.Product;

namespace Shopping_Core.Dtos.Products;

public class FilterProductsDto:BasePaging
{
    public List<ProductResponse> Products { get; set; }
    public string Title { get; set; }
    public decimal? StartPrice { get; set; }
    public decimal? EndPrice { get; set; }
    public List<long>? CategoryIds { get; set; }

    public ProductOrderBy? ProductOrderBy { get; set; }
    public FilterProductsDto SetPaging(BasePaging basePaging)
    {
        StartPage = basePaging.StartPage;
        EndPage = basePaging.EndPage;
        PageCount= basePaging.PageCount;
        ActivePage = basePaging.ActivePage;
        TakeEntity = basePaging.TakeEntity;
        SkipEntity = basePaging.SkipEntity;
        PageId = basePaging.PageId;
        return this;
    }

    public FilterProductsDto SetProducts(List<Product> products)
    {
        Products = products.Select(p=>new ProductResponse
        {
            Id = p.Id,
            Price = p.Price,
            Description = p.Description,
            ImageName = p.ImageName,
            ProductName = p.ProductName,
            IsExists = p.IsExists,
            IsSpecial = p.IsSpecial,
            ShortDescription = p.ShortDescription,
            CreateDate = p.CreateDate,
            Images = p.ProductGalleries.Select(pg=>new GalleryImageResponse
            {
                ImageName = pg.ImageName,
                ProductId = pg.ProductId
            }).ToList(),
        }).ToList();
        return this;
    }
}