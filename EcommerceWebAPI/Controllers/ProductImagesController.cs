using EcommerceWebAPI.Data;
using EcommerceWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductImagesController(AppDbContext context)
        {
            _context = context;
        }

        // Insert Image for Product
        [HttpPost]
        public async Task<IActionResult> AddImage([FromBody] ProductImages image)
        {
            _context.ProductImages.Add(image);
            await _context.SaveChangesAsync();
            return Ok(image);
        }

        // Get Images by ProductId
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetImagesByProduct(int productId)
        {
            var images = await _context.ProductImages
                .Where(i => i.ProductId == productId)
                .ToListAsync();

            return Ok(images);
        }

    }
}
