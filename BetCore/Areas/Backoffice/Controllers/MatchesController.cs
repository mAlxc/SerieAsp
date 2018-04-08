using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BetCore.Data;
using BetCoreModels.Models;
using BetCore.Filters;

namespace BetCore.Areas.Backoffice.Controllers
{
    [AuthenticationBackofficeFilter]
    public class MatchesController : BackofficeControllerBase
    {
        public MatchesController(BetCoreDbContext context) : base(context)
        {
        }

        // GET: Backoffice/Matches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Match.ToListAsync());
        }

        // GET: Backoffice/Matches/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .SingleOrDefaultAsync(m => m.ID == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Backoffice/Matches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Backoffice/Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Team1,Team2,OddTeam1,OddTeam2,OddDraw")] Match match)
        {
            if (ModelState.IsValid)
            {
                match.ID = Guid.NewGuid();
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }

        // GET: Backoffice/Matches/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.SingleOrDefaultAsync(m => m.ID == id);
            if (match == null)
            {
                return NotFound();
            }
            return View(match);
        }

        // POST: Backoffice/Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Team1,Team2,OddTeam1,OddTeam2,OddDraw,ID")] Match match)
        {
            if (id != match.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    match.UpdatedAt = DateTime.Now;
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }

        // GET: Backoffice/Matches/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .SingleOrDefaultAsync(m => m.ID == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Backoffice/Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var match = await _context.Match.SingleOrDefaultAsync(m => m.ID == id);
            //_context.Match.Remove(match);
            match.Deleted = true;
            match.DeletedAt = DateTime.Now;
            //_context.Entry(match).State = EntityState.Modified;
            _context.Match.Update(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(Guid id)
        {
            return _context.Match.Any(e => e.ID == id);
        }
    }
}
