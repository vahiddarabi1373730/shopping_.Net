using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shopping_Data_Layer.Common;
using Shopping_Data_Layer.Entities.Account;

namespace Shopping_Data_Layer.Entities.Product;

public class ProductComment:BaseEntity
{
    public long  UserId { get; set; }
    public long  ProductId { get; set; }
    
    [DisplayName("متن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(1000,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string Text { get; set; }


    #region Relations

    public User User { get; set; }
    public Product Product { get; set; }

    #endregion
}