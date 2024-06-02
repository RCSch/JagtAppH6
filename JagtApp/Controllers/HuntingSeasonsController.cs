using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagtApp.Data;
using JagtApp.Models;

namespace JagtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuntingSeasonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HuntingSeasonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HuntingSeasons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HuntingSeason>>> GetHuntingSeasons()
        {
            return await _context.HuntingSeasons.ToListAsync();
        }

        // GET: api/HuntingSeasons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HuntingSeason>> GetHuntingSeason(int id)
        {
            var huntingSeason = await _context.HuntingSeasons.FindAsync(id);

            if (huntingSeason == null)
            {
                return NotFound();
            }

            return huntingSeason;
        }
    }
}
