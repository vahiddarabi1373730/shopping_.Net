
using Shopping_Data_Layer.Entities.Site;

namespace Shopping_Core.Services.Interfaces
{
    public interface ISliderService : IDisposable
    {
        Task<List<Slider>> GetAllSliders();
        Task<List<Slider>> GetActiveSliders();
        Task AddSlider(Slider slider);
        Task UpdateSlider(Slider slider);
        Task<Slider> GetSliderById(long sliderId);
    }
}