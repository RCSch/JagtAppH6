using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirearmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FirearmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Firearms
        [HttpPost]
        public async Task<ActionResult<Firearm>> PostFirearm(Firearm firearm)
        {
            var owner = await _context.Users.FindAsync(firearm.OwnerId);

            if (owner == null)
            {
                return BadRequest("Invalid OwnerId");
            }

            firearm.Owner = owner;

            foreach (var caliber in firearm.SupportedCalibers)
            {
                var existingCaliber = await _context.Calibers.FindAsync(caliber.Id);
                if (existingCaliber == null)
                {
                    return BadRequest($"Invalid CaliberId: {caliber.Id}");
                }
            }

            _context.Firearms.Add(firearm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirearm", new { id = firearm.Id }, firearm);
        }

        // GET: api/Firearms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firearm>>> GetFirearms()
        {
            return await _context.Firearms
                .Include(f => f.Owner)
                .Include(f => f.SupportedCalibers)
                .ToListAsync();
        }

        // GET: api/Firearms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Firearm>> GetFirearm(int id)
        {
            var firearm = await _context.Firearms
                .Include(f => f.Owner)
                .Include(f => f.SupportedCalibers)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (firearm == null)
            {
                return NotFound();
            }

            return firearm;
        }

        // PUT: api/Firearms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirearm(int id, Firearm firearm)
        {
            if (id != firearm.Id)
            {
                return BadRequest();
            }

            _context.Entry(firearm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirearmExists(id))
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

        // DELETE: api/Firearms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirearm(int id)
        {
            var firearm = await _context.Firearms.FindAsync(id);
            if (firearm == null)
            {
                return NotFound();
            }

            _context.Firearms.Remove(firearm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FirearmExists(int id)
        {
            return _context.Firearms.Any(e => e.Id == id);
        }
    }
}
