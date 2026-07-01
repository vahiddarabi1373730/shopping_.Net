using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shopping_Data_Layer.Common;
using Shopping_Data_Layer.Entities.Access;
using Shopping_Data_Layer.Entities.Product;

namespace Shopping_Data_Layer.Entities.Account;

public class User:BaseEntity
{
    #region Properties

    [DisplayName("ایمیل")]
    [Required(ErrorMessage = "لطفا ایمیل را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Email { get; set; }
    
    [DisplayName("کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Password { get; set; }
    
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
    
    [DisplayName("موجودی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [Range(1,100000000,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public decimal Balance { get; set; }
    
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string EmailActiveCode { get; set; }
    
    public bool IsActivated { get; set; }
    

    #endregion
    
    #region Relations

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<ProductComment> ProductComments { get; set; }
    public ICollection<Order.Order> Orders { get; set; }
    public ICollection<Deposit> Deposits { get; set; }
    
    #endregion
}