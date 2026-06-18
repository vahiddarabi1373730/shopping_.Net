using System.ComponentModel.DataAnnotations;

namespace Shopping_Core.Dtos.Account;

public class EditUserInfoDto
{
    [Required(ErrorMessage = "لطفا نام را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "لطفا آدرس را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Address { get; set; }

}