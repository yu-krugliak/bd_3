﻿using System;
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
    public class VisitsController : Controller
    {
        private readonly DataBaseContext _context;

        public VisitsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Visits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visits.ToListAsync());
        }

        // GET: Visits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visits = await _context.Visits
                .FirstOrDefaultAsync(m => m.VS_ID == id);
            if (visits == null)
            {
                return NotFound();
            }

            return View(visits);
        }

        // GET: Visits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VS_ID,VS_DATE,VS_DESCRIPTION")] Visits visits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visits);
        }

        // GET: Visits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visits = await _context.Visits.FindAsync(id);
            if (visits == null)
            {
                return NotFound();
            }
            return View(visits);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VS_ID,VS_DATE,VS_DESCRIPTION")] Visits visits)
        {
            if (id != visits.VS_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitsExists(visits.VS_ID))
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
            return View(visits);
        }

        // GET: Visits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visits = await _context.Visits
                .FirstOrDefaultAsync(m => m.VS_ID == id);
            if (visits == null)
            {
                return NotFound();
            }

            return View(visits);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visits = await _context.Visits.FindAsync(id);
            _context.Visits.Remove(visits);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitsExists(int id)
        {
            return _context.Visits.Any(e => e.VS_ID == id);
        }
    }
}
