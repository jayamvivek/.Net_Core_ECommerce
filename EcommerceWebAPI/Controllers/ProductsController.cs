using EcommerceWebAPI.Data;
using EcommerceWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // Create Product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Products product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        // Get All Products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.Uom)
                .Include(p => p.Images)
                .ToListAsync();

            return Ok(products);
        }

        // Get Product by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Uom)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        // Edit Product
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] Products updatedProduct)
        {
            var product = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.UomId = updatedProduct.UomId;

            if (updatedProduct.Images != null && updatedProduct.Images.Any())
            {
                product.Images = updatedProduct.Images;
            }

            await _context.SaveChangesAsync();
            return Ok(product);
        }

    }
}
