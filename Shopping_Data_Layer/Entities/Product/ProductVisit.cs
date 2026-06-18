using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shopping_Data_Layer.Common;

namespace Shopping_Data_Layer.Entities.Product;

public class ProductVisit:BaseEntity
{
    #region Properties

    public long ProductId { get; set; }
    
    [DisplayName("IP")]
    [Required(ErrorMessage = "لطفا IP را وارد کنید.")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string UserIp { get; set; }
    
    #endregion
   
    
    #region Relations

    public Product Product { get; set; }
    
    #endregion
}