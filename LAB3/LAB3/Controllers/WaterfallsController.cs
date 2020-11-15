using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB3.Data;
using LAB3.Models;

namespace LAB3.Controllers
{
    public class WaterfallsController : Controller
    {
        private readonly DataBaseContext _context;

        public WaterfallsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Waterfalls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Waterfalls.ToListAsync());
        }

        // GET: Waterfalls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterfalls = await _context.Waterfalls
                .FirstOrDefaultAsync(m => m.WF_ID == id);
            if (waterfalls == null)
            {
                return NotFound();
            }

            return View(waterfalls);
        }

        // GET: Waterfalls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Waterfalls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WF_ID,WF_NAME,WF_HEIGHT")] Waterfalls waterfalls)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waterfalls);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waterfalls);
        }

        // GET: Waterfalls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterfalls = await _context.Waterfalls.FindAsync(id);
            if (waterfalls == null)
            {
                return NotFound();
            }
            return View(waterfalls);
        }

        // POST: Waterfalls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WF_ID,WF_NAME,WF_HEIGHT")] Waterfalls waterfalls)
        {
            if (id != waterfalls.WF_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waterfalls);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterfallsExists(waterfalls.WF_ID))
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
            return View(waterfalls);
        }

        // GET: Waterfalls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterfalls = await _context.Waterfalls
                .FirstOrDefaultAsync(m => m.WF_ID == id);
            if (waterfalls == null)
            {
                return NotFound();
            }

            return View(waterfalls);
        }

        // POST: Waterfalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterfalls = await _context.Waterfalls.FindAsync(id);
            _context.Waterfalls.Remove(waterfalls);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterfallsExists(int id)
        {
            return _context.Waterfalls.Any(e => e.WF_ID == id);
        }
    }
}
