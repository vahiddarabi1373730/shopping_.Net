namespace Shopping_Core.Models.ProductCategory;

public class ProductCategoryResponse
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string UrlTitle { get; set; }
    public long? ParentId { get; set; }
}

