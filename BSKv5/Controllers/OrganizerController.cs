using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BSKv5.Data;
using BSKv5.Models;

namespace BSKv5.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly BSKDbContext _context;

        public OrganizerController(BSKDbContext context)
        {
            _context = context;
        }

        // GET: Organizer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organizers.ToListAsync());
        }

        // GET: Organizer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizers
                .FirstOrDefaultAsync(m => m.orgID == id);
            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // GET: Organizer/Create
        public IActionResult Create(int id=0)
        {

            if (id == 0)
                return View(new Organizer());
            else

           
            return View(_context.Organizers.Find(id));
        }

        // POST: Organizer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("orgID,orgName,orgPhone,orgEmail,orgPassword")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {

                if (organizer.orgID == 0)

                    _context.Add(organizer);

                else
                    _context.Update(organizer);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizer);
        }

        // GET: Organizer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizers.FindAsync(id);
            if (organizer == null)
            {
                return NotFound();
            }
            return View(organizer);
        }

        // POST: Organizer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("orgID,orgName,orgPhone,orgEmail,orgPassword")] Organizer organizer)
        {
            if (id != organizer.orgID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizerExists(organizer.orgID))
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
            return View(organizer);
        }

        // GET: Organizer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var organizer = await _context.Organizers.FindAsync(id);
            _context.Organizers.Remove(organizer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Organizer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id);
            _context.Organizers.Remove(organizer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizerExists(int id)
        {
            return _context.Organizers.Any(e => e.orgID == id);
        }
    }
}
