using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shopping_Data_Layer.Common;
using Shopping_Data_Layer.Entities.Account;

namespace Shopping_Data_Layer.Entities.Order;

public class Order:BaseEntity
{
    
    [DisplayName("کاربر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public long  UserId { get; set; }
    
    [DisplayName("وضعیت پرداخت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public bool IsPay { get; set; }
    
    [DisplayName("تاریخ پرداخت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public DateTime PaymentDate { get; set; }
    

    #region Relations

    public User User { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }

    #endregion
}