using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Shopping_Data_Layer.Common;

namespace Shopping_Data_Layer.Entities.Account;

public class Withdraw:BaseEntity
{
    [DisplayName("آیدی کاربر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public long UserId { get; set; }
    [DisplayName("مبلغ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [Precision(18, 2)] 
    public decimal Amount { get; set; }
    [DisplayName("وضعیت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public WithdrawStatus Status { get; set; }

    #region Relations
    
    public User User { get; set; }
    
    #endregion
}


public enum WithdrawStatus
{
    Success,
    Failed,
    Pending
}