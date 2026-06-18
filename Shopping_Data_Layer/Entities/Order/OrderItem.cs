using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shopping_Data_Layer.Common;

namespace Shopping_Data_Layer.Entities.Order;

public class OrderItem:BaseEntity
{
    [DisplayName("صبد خرید")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public long OrderId { get; set; }
    [DisplayName("محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public long ProductId { get; set; }
    [DisplayName("قیمت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public decimal Price { get; set; }
    [DisplayName("تعداد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public int Count { get; set; }

    #region Relations

    public Order Order { get; set; }
    public Product.Product Product { get; set; }
    

    #endregion
}