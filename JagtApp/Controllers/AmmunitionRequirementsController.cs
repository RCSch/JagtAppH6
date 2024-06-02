using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmmunitionRequirementsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AmmunitionRequirementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AmmunitionRequirements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmmunitionRequirements>>> GetAmmunitionRequirements()
        {
            return await _context.AmmunitionRequirements.ToListAsync();
        }

        // GET: api/AmmunitionRequirements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmmunitionRequirements>> GetAmmunitionRequirements(int id)
        {
            var ammunitionRequirements = await _context.AmmunitionRequirements.FindAsync(id);

            if (ammunitionRequirements == null)
            {
                return NotFound();
            }

            return ammunitionRequirements;
        }
    }
}
