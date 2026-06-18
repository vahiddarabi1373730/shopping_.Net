using System.ComponentModel.DataAnnotations;

namespace Shopping_Core.Models.Order;

public class AddProductToOrderRequest
{
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public int Count { get; set; }
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public int ProductId { get; set; }

}