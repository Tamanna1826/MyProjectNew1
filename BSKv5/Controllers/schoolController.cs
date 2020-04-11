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
    public class schoolController : Controller
    {
        private readonly BSKDbContext _context;

        public schoolController(BSKDbContext context)
        {
            _context = context;
        }

        // GET: school
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schools.ToListAsync());
        }

        // GET: school/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.Schools
                .FirstOrDefaultAsync(m => m.SchoolID == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: school/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: school/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolID,SchoolCode,SchoolName,orgID")] school school)
        {
            if (ModelState.IsValid)
            {
                _context.Add(school);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        // GET: school/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // POST: school/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchoolID,SchoolCode,SchoolName,orgID")] school school)
        {
            if (id != school.SchoolID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!schoolExists(school.SchoolID))
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
            return View(school);
        }

        // GET: school/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.Schools
                .FirstOrDefaultAsync(m => m.SchoolID == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: school/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool schoolExists(int id)
        {
            return _context.Schools.Any(e => e.SchoolID == id);
        }
    }
}
