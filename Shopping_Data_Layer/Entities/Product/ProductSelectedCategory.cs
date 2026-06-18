using Shopping_Data_Layer.Common;

namespace Shopping_Data_Layer.Entities.Product;

public class ProductSelectedCategory:BaseEntity
{
    #region Properties
    
    public long ProductId { get; set; }

    public long ProductCategoryId { get; set; }


    #endregion
   
    #region Relations

    public Product Product { get; set; }
    public ProductCategory ProductCategory { get; set; }

    #endregion
}