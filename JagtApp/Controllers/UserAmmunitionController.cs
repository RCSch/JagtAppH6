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
    public class UserAmmunitionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserAmmunitionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserAmmunition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAmmunition>>> GetUserAmmunitions()
        {
            return await _context.UserAmmunitions
                .Include(ua => ua.AssociatedCartridge)
                .Include(ua => ua.Owner)
                .ToListAsync();
        }

        // GET: api/UserAmmunition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAmmunition>> GetUserAmmunition(int id)
        {
            var userAmmunition = await _context.UserAmmunitions
                .Include(ua => ua.AssociatedCartridge)
                .Include(ua => ua.Owner)
                .FirstOrDefaultAsync(ua => ua.Id == id);

            if (userAmmunition == null)
            {
                return NotFound();
            }

            return userAmmunition;
        }

        // PUT: api/UserAmmunition/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAmmunition(int id, UserAmmunition userAmmunition)
        {
            if (id != userAmmunition.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAmmunition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAmmunitionExists(id))
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

        // POST: api/UserAmmunition
        [HttpPost]
        public async Task<ActionResult<UserAmmunition>> PostUserAmmunition(UserAmmunition userAmmunition)
        {
            _context.UserAmmunitions.Add(userAmmunition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAmmunition", new { id = userAmmunition.Id }, userAmmunition);
        }

        // DELETE: api/UserAmmunition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAmmunition(int id)
        {
            var userAmmunition = await _context.UserAmmunitions.FindAsync(id);
            if (userAmmunition == null)
            {
                return NotFound();
            }

            _context.UserAmmunitions.Remove(userAmmunition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAmmunitionExists(int id)
        {
            return _context.UserAmmunitions.Any(e => e.Id == id);
        }
    }
}
