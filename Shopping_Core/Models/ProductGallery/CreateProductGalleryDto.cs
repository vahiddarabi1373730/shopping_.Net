using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Shopping_Data_Layer.Common;

namespace Shopping_Core.Models.ProductGallery;

public class CreateProductGalleryDto:BaseDto
{
    
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [DisplayName("محصول")]
    public long? ProductId { get; set; }
    
    [Required(ErrorMessage = "لطفا {0} را انتخاب کنید.")]
    [DisplayName("تصویر")]

    public IFormFile ImageFile { get; set; }

}