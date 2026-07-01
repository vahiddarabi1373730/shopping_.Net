using Shopping_Core.Dtos.Paging;

namespace Shopping_Core.Models.ProductCategory;

public class ProductCategoryRequest:BasePaging
{
    public string Title { get; set; }
    public string UrlTitle { get; set; }
    public long? ParentId { get; set; }
}

