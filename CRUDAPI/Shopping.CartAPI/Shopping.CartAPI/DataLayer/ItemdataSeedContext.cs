using System.Text.Json;
using Shopping.Models.Entities;

namespace Shopping.CartAPI.DataLayer
{
    public class ItemdataSeedContext
    {
        public static async Task SeedData(DataContext dataContext)
        {
            if (!dataContext.Products.Any())
            {
                var SeedData = await File.ReadAllTextAsync("../shopping.CartApi/DataLayer/ProductItemSeed.json");
                var products = JsonSerializer.Deserialize<List<Products>>(SeedData);
                if(products != null)
                {
                    await dataContext.AddRangeAsync(products);
                    await dataContext.SaveChangesAsync();
                }
            }
        }
    }
}