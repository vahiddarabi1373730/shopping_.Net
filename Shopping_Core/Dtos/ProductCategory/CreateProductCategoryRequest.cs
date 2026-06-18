using System.ComponentModel.DataAnnotations;

namespace Shopping_Core.Dtos.ProductCategory;

public class CreateProductCategoryRequest
{
    [Required(ErrorMessage = "لطفا عنوان را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string UrlTitle { get; set; }

}