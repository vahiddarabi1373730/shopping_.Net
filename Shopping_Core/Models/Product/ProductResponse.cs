using Shopping_Core.Models.ProductGallery;

namespace Shopping_Core.Models.Product;

public class ProductResponse
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string ImageName { get; set; }
    public int Price { get; set; }
    public bool IsExists { get; set; }
    public bool IsSpecial { get; set; }
    public DateTime CreateDate { get; set; }
    public List<GalleryImageResponse> Images { get; set; }
}