using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartridgesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartridgesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cartridges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cartridge>>> GetCartridges()
        {
            return await _context.Cartridges.Include(c => c.AssociatedBullet).Include(c => c.AssociatedCaliber).ToListAsync();
        }

        // GET: api/Cartridges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cartridge>> GetCartridge(int id)
        {
            var cartridge = await _context.Cartridges.Include(c => c.AssociatedBullet).Include(c => c.AssociatedCaliber).FirstOrDefaultAsync(c => c.Id == id);

            if (cartridge == null)
            {
                return NotFound();
            }

            return cartridge;
        }

        // PUT: api/Cartridges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartridge(int id, Cartridge cartridge)
        {
            if (id != cartridge.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartridge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartridgeExists(id))
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

        // POST: api/Cartridges
        [HttpPost]
        public async Task<ActionResult<Cartridge>> PostCartridge(Cartridge cartridge)
        {
            var bullet = await _context.Bullets.FindAsync(cartridge.BulletId);
            var caliber = await _context.Calibers.FindAsync(cartridge.CaliberId);

            if (bullet == null || caliber == null)
            {
                return BadRequest("Invalid BulletId or CaliberId");
            }

            cartridge.AssociatedBullet = bullet;
            cartridge.AssociatedCaliber = caliber;

            _context.Cartridges.Add(cartridge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartridge", new { id = cartridge.Id }, cartridge);
        }

        // DELETE: api/Cartridges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartridge(int id)
        {
            var cartridge = await _context.Cartridges.FindAsync(id);
            if (cartridge == null)
            {
                return NotFound();
            }

            _context.Cartridges.Remove(cartridge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartridgeExists(int id)
        {
            return _context.Cartridges.Any(e => e.Id == id);
        }
    }
}
