using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameAnimalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameAnimalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameAnimals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameAnimal>>> GetGameAnimals()
        {
            return await _context.GameAnimals
                .Include(ga => ga.HuntingSeasons)
                .ToListAsync();
        }

        // GET: api/GameAnimals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameAnimal>> GetGameAnimal(int id)
        {
            var gameAnimal = await _context.GameAnimals
                .Include(ga => ga.HuntingSeasons)
                .FirstOrDefaultAsync(ga => ga.Id == id);

            if (gameAnimal == null)
            {
                return NotFound();
            }

            return gameAnimal;
        }

        // PUT: api/GameAnimals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameAnimal(int id, GameAnimal gameAnimal)
        {
            if (id != gameAnimal.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameAnimalExists(id))
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

        // POST: api/GameAnimals
        [HttpPost]
        public async Task<ActionResult<GameAnimal>> PostGameAnimal(GameAnimal gameAnimal)
        {
            _context.GameAnimals.Add(gameAnimal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameAnimal", new { id = gameAnimal.Id }, gameAnimal);
        }

        // DELETE: api/GameAnimals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameAnimal(int id)
        {
            var gameAnimal = await _context.GameAnimals.FindAsync(id);
            if (gameAnimal == null)
            {
                return NotFound();
            }

            _context.GameAnimals.Remove(gameAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameAnimalExists(int id)
        {
            return _context.GameAnimals.Any(e => e.Id == id);
        }
    }
}
