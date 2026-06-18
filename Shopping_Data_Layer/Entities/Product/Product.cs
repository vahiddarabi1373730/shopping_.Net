using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shopping_Data_Layer.Common;
using Shopping_Data_Layer.Entities.Order;

namespace Shopping_Data_Layer.Entities.Product;

public class Product:BaseEntity
{
    [DisplayName("نام محصول")]
    [Required(ErrorMessage = "لطفا تصویر را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string ProductName { get; set; }
    
    [DisplayName("توضیحات کوتاه")]
    [Required(ErrorMessage = "لطفا توضیحات کوتاه را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string ShortDescription { get; set; }
    
    [DisplayName("توضیحات")]
    [Required(ErrorMessage = "لطفا توضیحات را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Description { get; set; }
    
    [DisplayName("نام تصویر")]
    [Required(ErrorMessage = "لطفا تصویر را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string ImageName { get; set; }
    
    [DisplayName("قیمت")]
    [Required(ErrorMessage = "لطفا قیمت را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public int Price { get; set; }
    
    [DisplayName("موجود/به اتمام رسیده")]
    public bool IsExists { get; set; }
    
    [DisplayName("ویژه")]
    public bool IsSpecial { get; set; }

    #region Relations

    public ICollection<ProductGallery> ProductGalleries { get; set; }
    public ICollection<ProductVisit> ProductVisits { get; set; }
    public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }
    public ICollection<ProductComment> ProductComments { get; set; }
    public ICollection<OrderItem> OrderDetails { get; set; }

    #endregion

}