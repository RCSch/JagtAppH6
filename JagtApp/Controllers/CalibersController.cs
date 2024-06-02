using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalibersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalibersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE
        // POST: api/Calibers
        [HttpPost]
        public async Task<ActionResult<Caliber>> PostCaliber(Caliber caliber)
        {
            _context.Calibers.Add(caliber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaliber", new { id = caliber.Id }, caliber);
        }

        //READ
        // GET: api/Calibers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caliber>>> GetCalibers()
        {
            return await _context.Calibers.ToListAsync();
        }

        // GET: api/Calibers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caliber>> GetCaliber(int id)
        {
            var caliber = await _context.Calibers.FindAsync(id);

            if (caliber == null)
            {
                return NotFound();
            }

            return caliber;
        }

        //UPDATE
        // PUT: api/Calibers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaliber(int id, Caliber caliber)
        {
            if (id != caliber.Id)
            {
                return BadRequest();
            }

            _context.Entry(caliber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaliberExists(id))
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
        private bool CaliberExists(int id)
        {
            return _context.Calibers.Any(e => e.Id == id);
        }


        // DELETE
        // DELETE: api/Calibers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaliber(int id)
        {
            var caliber = await _context.Calibers.FindAsync(id);
            if (caliber == null)
            {
                return NotFound();
            }

            _context.Calibers.Remove(caliber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
