using System.ComponentModel.DataAnnotations;

namespace Shopping_Data_Layer.Common;

public class BaseDto
{
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public bool IsDelete  { get; set; }
   
}