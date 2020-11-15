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
    public class RiversController : Controller
    {
        private readonly DataBaseContext _context;

        public RiversController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Rivers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rivers.ToListAsync());
        }

        // GET: Rivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var rivers = await _context.Rivers
                .FirstOrDefaultAsync(m => m.RV_ID == id);
            if (rivers == null)
            {
                return NotFound();
            }

            return View(rivers);
        }

        // GET: Rivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RV_ID,RV_NAME")] Rivers rivers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rivers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rivers);
        }

        // GET: Rivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rivers = await _context.Rivers.FindAsync(id);
            if (rivers == null)
            {
                return NotFound();
            }
            return View(rivers);
        }

        // POST: Rivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RV_ID,RV_NAME")] Rivers rivers)
        {
            if (id != rivers.RV_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rivers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiversExists(rivers.RV_ID))
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
            return View(rivers);
        }

        // GET: Rivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rivers = await _context.Rivers
                .FirstOrDefaultAsync(m => m.RV_ID == id);
            if (rivers == null)
            {
                return NotFound();
            }

            return View(rivers);
        }

        // POST: Rivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rivers = await _context.Rivers.FindAsync(id);
            _context.Rivers.Remove(rivers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiversExists(int id)
        {
            return _context.Rivers.Any(e => e.RV_ID == id);
        }
    }
}
