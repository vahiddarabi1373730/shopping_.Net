using System.ComponentModel.DataAnnotations;

namespace Shopping_Core.Dtos.Account;

public class UserRequest
{
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Email { get; set; }
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Password { get; set; }
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Address { get; set; }
}