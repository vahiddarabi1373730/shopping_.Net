using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Shopping_Data_Layer.Common;

namespace Shopping_Core.Models.Product;

public class CrudProductDto:BaseDto
{
    [Required(ErrorMessage = "لطفا نام محصول را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string ProductName { get; set; }
    
    [Required(ErrorMessage = "لطفا توضیحات کوتاه را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string ShortDescription { get; set; }
    
    [Required(ErrorMessage = "لطفا توضیحات را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "لطفا تصویر را وارد کنید.")]
    public IFormFile ImageFile { get; set; }
    
    [Required(ErrorMessage = "لطفا قیمت را وارد کنید.")]
    [Range(0,100000,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public int Price { get; set; }
    
    [Required(ErrorMessage = "لطفا وجود کالا را مشخص کنید.")]
    public bool IsExists { get; set; }
    
    [Required(ErrorMessage = "لطفا ویژه بودن کالا  را مشخص کنید.")]
    public bool IsSpecial { get; set; }
    
    [Required(ErrorMessage = "لطفا تاریخ را مشخص کنید.")]
    public string CreateDate { get; set; }
}