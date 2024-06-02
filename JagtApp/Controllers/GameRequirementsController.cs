using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRequirementsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameRequirementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameRequirements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameRequirements>>> GetGameRequirements()
        {
            return await _context.GameRequirements
                .Include(gr => gr.AmmoRequirements)
                .ToListAsync();
        }

        // GET: api/GameRequirements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameRequirements>> GetGameRequirements(int id)
        {
            var gameRequirements = await _context.GameRequirements
                .Include(gr => gr.AmmoRequirements)
                .FirstOrDefaultAsync(gr => gr.Id == id);

            if (gameRequirements == null)
            {
                return NotFound();
            }

            return gameRequirements;
        }
    }
}
