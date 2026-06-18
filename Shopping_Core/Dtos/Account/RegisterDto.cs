using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopping_Core.Dtos.Account;

public class RegisterDto
{
    [DisplayName("ایمیل")]
    [Required(ErrorMessage = "لطفا ایمیل را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Email { get; set; }
    
    [DisplayName("کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Password { get; set; }
    
    [DisplayName("تکرار کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    
    [DisplayName("نام")]
    [Required(ErrorMessage = "لطفا نام را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string FirstName { get; set; }
    
    [DisplayName("نام خانوادگی")]
    [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string LastName { get; set; }
    
    [DisplayName("آدرس")]
    [Required(ErrorMessage = "لطفا آدرس را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Address { get; set; }
}