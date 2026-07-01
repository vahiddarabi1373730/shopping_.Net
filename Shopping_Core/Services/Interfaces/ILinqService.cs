using Shopping_Core.Models.ProductCategory;
using Shopping_Data_Layer.Entities.Product;

namespace Shopping_Core.Services.Interfaces;

public interface ILinqService
{
    public Task<List<ProductCategory>> GetAll();
}