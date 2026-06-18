using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopping_Core.Dtos.Account;

public class LoginDto
{
    [DisplayName("ایمیل")]
    [Required(ErrorMessage = "لطفا ایمیل را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Email { get; set; }
    
    [DisplayName("کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Password { get; set; }
    
}