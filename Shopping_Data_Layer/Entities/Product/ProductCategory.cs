using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shopping_Data_Layer.Common;

namespace Shopping_Data_Layer.Entities.Product;

public class ProductCategory:BaseEntity
{
    #region Properties

    [DisplayName("عنوان")]
    [Required(ErrorMessage = "لطفا عنوان را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Title { get; set; }

    [DisplayName("عنوان لینک")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string UrlTitle { get; set; }

    
    public long? ParentId { get; set; }


    #endregion
   
    #region Relations

    [ForeignKey(nameof(ParentId))]
    public ProductCategory ParentCategory { get; set; }

    public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }

    #endregion
    
}