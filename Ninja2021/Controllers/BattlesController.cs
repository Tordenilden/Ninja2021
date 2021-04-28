using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ninja2021.Models;

namespace Ninja2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BattlesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Battles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battle>>> GetBattles()
        {
            return await _context.Battles.ToListAsync();
        }

        // GET: api/Battles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Battle>> GetBattle(int id)
        {
            var battle = await _context.Battles.FindAsync(id);

            if (battle == null)
            {
                return NotFound();
            }

            return battle;
        }

        // PUT: api/Battles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattle(int id, Battle battle)
        {
            if (id != battle.battleId)
            {
                return BadRequest();
            }

            _context.Entry(battle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattleExists(id))
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

        // POST: api/Battles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Battle>> PostBattle(Battle battle)
        {
            _context.Battles.Add(battle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattle", new { id = battle.battleId }, battle);
        }

        // DELETE: api/Battles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Battle>> DeleteBattle(int id)
        {
            var battle = await _context.Battles.FindAsync(id);
            if (battle == null)
            {
                return NotFound();
            }

            _context.Battles.Remove(battle);
            await _context.SaveChangesAsync();

            return battle;
        }

        private bool BattleExists(int id)
        {
            return _context.Battles.Any(e => e.battleId == id);
        }
    }
}
