using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombinationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CombinationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Combinations
        [HttpPost]
        public async Task<ActionResult<Combination>> PostCombination(Combination combination)
        {
            var associatedCartridge = await _context.Cartridges
                .Include(c => c.AssociatedBullet)
                .Include(c => c.AssociatedCaliber)
                .FirstOrDefaultAsync(c => c.Id == combination.AssociatedCartridge.Id);

            if (associatedCartridge == null)
            {
                return BadRequest("Invalid CartridgeId");
            }

            var associatedFirearm = await _context.Firearms.FindAsync(combination.AssociatedFirearm.Id);
            if (associatedFirearm == null)
            {
                return BadRequest("Invalid FirearmId");
            }

            var legalityRequirements = await _context.GameRequirements
                .Include(l => l.AmmoRequirements)
                .FirstOrDefaultAsync(l => l.Id == combination.LegalityRequirements.Id);

            if (legalityRequirements == null)
            {
                return BadRequest("Invalid GameRequirementsId");
            }

            combination.AssociatedCartridge = associatedCartridge;
            combination.AssociatedFirearm = associatedFirearm;
            combination.LegalityRequirements = legalityRequirements;

            // Beregn V100 og E100
            combination.V100 = CalculateV100(combination.V0, associatedCartridge.AssociatedBullet);
            combination.E100 = CalculateE100(combination.V100, associatedCartridge.AssociatedBullet);
            combination.E0 = CalculateE0(combination.V0, associatedCartridge.AssociatedBullet);

            _context.Combinations.Add(combination);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCombination", new { id = combination.Id }, combination);
        }
        private double CalculateV100(double v0, Bullet bullet)
        {
            double dragCoefficient = 0.3; // Omtrentlig "drag coefficient"
            double densityAir = 1.225; // Luftdensitet ved havniveau (i kg/m^3)
            double bulletWeight = bullet.BulletWeight;
            double bc = bullet.BallisticCoefficient;
            double distance = 100; // Afstand på 100 meter

            double v100 = Math.Sqrt(v0 * v0 - (2 * dragCoefficient * bulletWeight * densityAir * distance)) /
                          (1 + (0.5 * dragCoefficient * bulletWeight * densityAir * distance) / (bc * v0));

            return v100;
        }

        private double CalculateE0(double v0, Bullet bullet)
        {
            double bulletWeight = bullet.BulletWeight / 1000;
            return v0 * v0 * bulletWeight / 2;
        }

        private double CalculateE100(double v100, Bullet bullet)
        {
            double bulletWeight = bullet.BulletWeight / 1000;
            return v100 * v100 * bulletWeight / 2;
        }

        // GET: api/Combinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Combination>>> GetCombinations()
        {
            return await _context.Combinations
                .Include(c => c.AssociatedCartridge)
                    .ThenInclude(c => c.AssociatedBullet)
                .Include(c => c.AssociatedCartridge)
                    .ThenInclude(c => c.AssociatedCaliber)
                .Include(c => c.AssociatedFirearm)
                .Include(c => c.LegalityRequirements)
                    .ThenInclude(l => l.AmmoRequirements)
                .ToListAsync();
        }

        // GET: api/Combinations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Combination>> GetCombination(int id)
        {
            var combination = await _context.Combinations
                .Include(c => c.AssociatedCartridge)
                    .ThenInclude(c => c.AssociatedBullet)
                .Include(c => c.AssociatedCartridge)
                    .ThenInclude(c => c.AssociatedCaliber)
                .Include(c => c.AssociatedFirearm)
                .Include(c => c.LegalityRequirements)
                    .ThenInclude(l => l.AmmoRequirements)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (combination == null)
            {
                return NotFound();
            }

            return combination;
        }

        // PUT: api/Combinations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCombination(int id, Combination combination)
        {
            if (id != combination.Id)
            {
                return BadRequest();
            }

            _context.Entry(combination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CombinationExists(id))
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

        // DELETE: api/Combinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCombination(int id)
        {
            var combination = await _context.Combinations.FindAsync(id);
            if (combination == null)
            {
                return NotFound();
            }

            _context.Combinations.Remove(combination);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CombinationExists(int id)
        {
            return _context.Combinations.Any(e => e.Id == id);
        }
    }
}
