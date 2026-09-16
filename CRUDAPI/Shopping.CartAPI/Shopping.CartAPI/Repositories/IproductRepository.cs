using Shopping.Models.Entities;

namespace Shopping.CartAPI.Repositories
{
    public interface IproductRepository
    {
        Task<List<Products>> GetProductsAsync();
    }
}
