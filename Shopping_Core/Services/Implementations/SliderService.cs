using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Site;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class SliderService(IGenericRepository<Slider> genericRepository):ISliderService
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<List<Slider>> GetAllSliders()
    {
        throw new NotImplementedException();
    }

    public Task<List<Slider>> GetActiveSliders()
    {
        throw new NotImplementedException();
    }

    public Task AddSlider(Slider slider)
    {
        throw new NotImplementedException();
    }

    public Task UpdateSlider(Slider slider)
    {
        throw new NotImplementedException();
    }

    public Task<Slider> GetSliderById(long sliderId)
    {
        throw new NotImplementedException();
    }
}