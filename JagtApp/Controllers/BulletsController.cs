using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulletsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BulletsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE
        // POST: api/Bullets
        [HttpPost]
        public async Task<ActionResult<Bullet>> PostBullet(Bullet bullet)
        {
            _context.Bullets.Add(bullet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBullet", new { id = bullet.Id }, bullet);
        }

        // READ
        // GET: api/Bullets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bullet>>> GetBullets()
        {
            return await _context.Bullets.ToListAsync();
        }

        // GET: api/Bullets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bullet>> GetBullet(int id)
        {
            var bullet = await _context.Bullets.FindAsync(id);

            if (bullet == null)
            {
                return NotFound();
            }

            return bullet;
        }

        // UPDATE
        // PUT: api/Bullets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBullet(int id, Bullet bullet)
        {
            if (id != bullet.Id)
            {
                return BadRequest();
            }

            _context.Entry(bullet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BulletExists(id))
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

        private bool BulletExists(int id)
        {
            return _context.Bullets.Any(e => e.Id == id);
        }


        // DELETE
        // DELETE: api/Bullets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBullet(int id)
        {
            var bullet = await _context.Bullets.FindAsync(id);
            if (bullet == null)
            {
                return NotFound();
            }

            _context.Bullets.Remove(bullet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
