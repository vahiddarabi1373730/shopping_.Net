using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shopping_Data_Layer.Common;

namespace Shopping_Data_Layer.Entities.Access;

public class Role:BaseEntity
{
    #region Properties

    [DisplayName("نام سیستمی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Name { get; set; }
    
    [DisplayName("عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Title { get; set; }
    
    #endregion
    
    
    #region Relations

    public ICollection<UserRole> UserRoles { get; set; }
    
    #endregion
    
    
}