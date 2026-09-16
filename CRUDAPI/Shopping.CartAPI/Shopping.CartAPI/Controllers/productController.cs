using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.CartAPI.DataLayer;
using Shopping.CartAPI.Repositories;
using Shopping.Models.Entities;

namespace Shopping.CartAPI.Controllers
{
    public class productController : ControllerBase
    {
        private IproductRepository _productsData;
        public productController(IproductRepository products)
        {
            _productsData = products;
        }

        [HttpGet("getProducts")]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            return Ok(await _productsData.GetProductsAsync());
        }
    }
}
