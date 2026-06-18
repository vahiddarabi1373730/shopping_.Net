using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shopping_Data_Layer.Common;

namespace Shopping_Data_Layer.Entities.Product;

public class ProductGallery:BaseEntity
{
    public long ProductId { get; set; }
    
    [DisplayName("نام تصویر")]
    [Required(ErrorMessage = "لطفا تصویر را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string ImageName  { get; set; }


    #region Relations
    
    public Product Product  { get; set; }

    #endregion
}