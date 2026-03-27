using EcommerceWebAPI.APIResponse;
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
    public class UomTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UomTypesController(AppDbContext context)
        {
            _context = context;
        }

        // Insert UOM Type
        [HttpPost]
        public async Task<IActionResult> CreateUomType([FromBody] UomTypes uomType)
        {
            if (uomType == null)
                return BadRequest();

            // Check if a UOM Type with the same name already exists
            var exists = await _context.UomTypes
                                       .AnyAsync(x => x.Name.ToLower() == uomType.Name.ToLower());

            if (exists)
            {
                return Conflict(new JsonResponse().Error($"UOM Type with name '{uomType.Name}' already exists"));
            }



            _context.UomTypes.Add(uomType);
            await _context.SaveChangesAsync();
            return Ok(uomType);
        }

        // Get All UOM Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UomTypes>>> GetUomTypes()
        {
            var uomTypes = await _context.UomTypes.ToListAsync();
            return Ok(uomTypes);
        }

        // Get UOM Type by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUomTypeById(int id)
        {
            var uomType = await _context.UomTypes.FindAsync(id);
            if (uomType == null)
                return NotFound();

            return Ok(uomType);
        }

        // Update UOM Type
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUomType(int id, [FromBody] UomTypes updatedUomType)
        {
            if (id != updatedUomType.Id)
                return BadRequest("ID mismatch");

            var existingUomType = await _context.UomTypes.FindAsync(id);
            if (existingUomType == null)
                return NotFound();

            // Update fields
            existingUomType.Name = updatedUomType.Name; 

            _context.UomTypes.Update(existingUomType);
            await _context.SaveChangesAsync();

            return Ok(existingUomType);
        }

        // DELETE: api/UomTypes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUomType(int id)
        {
            var uomType = await _context.UomTypes.FindAsync(id);
            if (uomType == null)
            {
                return NotFound(new JsonResponse().Error($"UOM Type with Id {id} not found"));
            }
             
            _context.UomTypes.Remove(uomType);
            await _context.SaveChangesAsync();


            return Ok(new JsonResponse().Success(null, $"UOM Type with Id {id} deleted successfully"));
        }

    }
}
