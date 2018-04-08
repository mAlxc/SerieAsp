using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BetCore.Data;
using BetCoreModels.Models;

namespace BetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Matches")]
    public class MatchesController : Controller
    {
        private readonly BetCoreDbContext _context;

        public MatchesController(BetCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Matches
        [HttpGet]
        public IEnumerable<Match> GetMatch()
        {
            return _context.Match.Where(x => !x.Deleted);
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = await _context.Match.SingleOrDefaultAsync(m => m.ID == id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // PUT: api/Matches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch([FromRoute] Guid id, [FromBody] Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != match.ID)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        // POST: api/Matches
        [HttpPost]
        public async Task<IActionResult> PostMatch([FromBody] Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Match.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatch", new { id = match.ID }, match);
        }

        // DELETE: api/Matches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = await _context.Match.SingleOrDefaultAsync(m => m.ID == id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Match.Remove(match);
            await _context.SaveChangesAsync();

            return Ok(match);
        }

        private bool MatchExists(Guid id)
        {
            return _context.Match.Any(e => e.ID == id);
        }
    }
}