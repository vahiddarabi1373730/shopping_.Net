using Microsoft.AspNetCore.Mvc;
using Shopping_Core.Services.Interfaces;
using Shopping_Core.Utilities.Common;

namespace Shopping_Api.Controllers;

public class SliderController(ISliderService sliderService):BaseController
{
    private ISliderService SliderService { get; set; } = sliderService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await SliderService.GetAllSliders();
        return JsonResponse.Success(data);
    }
}