using Microsoft.EntityFrameworkCore;
using Shopping.CartAPI.DataLayer;
using Shopping.Models.Entities;

namespace Shopping.CartAPI.Repositories
{
    public class ProductRepository : IproductRepository
    {
        DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Products>> GetProductsAsync()
        {
            return await _dataContext.Products.ToListAsync<Products>();
        }
    }
}
