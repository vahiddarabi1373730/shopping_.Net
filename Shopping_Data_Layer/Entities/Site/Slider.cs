using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shopping_Data_Layer.Common;

namespace Shopping_Data_Layer.Entities.Site;

public class Slider:BaseEntity
{
    #region Properties

    [DisplayName("عنوان")]
    [Required(ErrorMessage = "لطفا عنوان را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Title { get; set; }
    
    [DisplayName("توضیحات")]
    [Required(ErrorMessage = "لطفا توضیحات را وارد کنید.")]
    [MaxLength(1000,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Description { get; set; }
    
    [DisplayName("آدرس")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Link { get; set; }
    
    [DisplayName("تصویر")]
    [Required(ErrorMessage = "لطفا تصویر را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string ImageName { get; set; }

    #endregion
   
}