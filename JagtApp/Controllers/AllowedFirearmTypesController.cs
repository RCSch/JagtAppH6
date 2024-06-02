using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllowedFirearmTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AllowedFirearmTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AllowedFirearmTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllowedFirearmType>>> GetAllowedFirearmTypes()
        {
            return await _context.AllowedFirearmTypes
                .Include(aft => aft.GameRequirement)
                .ToListAsync();
        }

        // GET: api/AllowedFirearmTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllowedFirearmType>> GetAllowedFirearmType(int id)
        {
            var allowedFirearmType = await _context.AllowedFirearmTypes
                .Include(aft => aft.GameRequirement)
                .FirstOrDefaultAsync(aft => aft.Id == id);

            if (allowedFirearmType == null)
            {
                return NotFound();
            }

            return allowedFirearmType;
        }

        // PUT: api/AllowedFirearmTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllowedFirearmType(int id, AllowedFirearmType allowedFirearmType)
        {
            if (id != allowedFirearmType.Id)
            {
                return BadRequest();
            }

            _context.Entry(allowedFirearmType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllowedFirearmTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AllowedFirearmTypes
        [HttpPost]
        public async Task<ActionResult<AllowedFirearmType>> PostAllowedFirearmType(AllowedFirearmType allowedFirearmType)
        {
            _context.AllowedFirearmTypes.Add(allowedFirearmType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllowedFirearmType", new { id = allowedFirearmType.Id }, allowedFirearmType);
        }

        // DELETE: api/AllowedFirearmTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllowedFirearmType(int id)
        {
            var allowedFirearmType = await _context.AllowedFirearmTypes.FindAsync(id);
            if (allowedFirearmType == null)
            {
                return NotFound();
            }

            _context.AllowedFirearmTypes.Remove(allowedFirearmType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllowedFirearmTypeExists(int id)
        {
            return _context.AllowedFirearmTypes.Any(e => e.Id == id);
        }
    }
}
