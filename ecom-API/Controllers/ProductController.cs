using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecom_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _storeContext;

        public ProductController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        [HttpGet("get-products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _storeContext.Products.ToListAsync();
            return Ok(products);

        }

        [HttpGet("get-product/{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            return await _storeContext.Products.FindAsync(id);
                 
        }

    }
}
