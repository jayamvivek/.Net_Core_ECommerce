using EcommerceWebAPI.Data;
using EcommerceWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UomsController(AppDbContext context)
        {
            _context = context;
        }

        // Insert UOM
        [HttpPost]
        public async Task<IActionResult> CreateUom([FromBody] Uoms uom)
        {
            _context.Uoms.Add(uom);
            await _context.SaveChangesAsync();
            return Ok(uom);
        }

        // Get All UOMs
        [HttpGet]
        public async Task<IActionResult> GetUoms()
        {
            var uoms = await _context.Uoms.ToListAsync();
            return Ok(uoms);
        }

    }
}
