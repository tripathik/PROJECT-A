using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Controllers
{
    public class AllocatesController : Controller
    {
        private readonly TMSContext _context;

        public AllocatesController(TMSContext context)
        {
            _context = context;
        }

        // GET: Allocates
        public async Task<IActionResult> Index()
        {
            var tMSContext = _context.Allocates.Include(a => a.Employee).Include(a => a.Route).Include(a => a.Vehicle);
            return View(await tMSContext.ToListAsync());
        }

        // GET: Allocates/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocate = await _context.Allocates
                .Include(a => a.Employee)
                .Include(a => a.Route)
                .Include(a => a.Vehicle)
                .FirstOrDefaultAsync(m => m.AllocateId == id);
            if (allocate == null)
            {
                return NotFound();
            }

            return View(allocate);
        }

        // GET: Allocates/Create
        public IActionResult Create()
        {
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId");
            ViewData["RouteNumber"] = new SelectList(_context.Routes, "RouteNumber", "RouteNumber");
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicles, "VehicleNumber", "VehicleNumber");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocateId,EmpId,VehicleNumber,RouteNumber")] Allocate allocate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", allocate.EmpId);
            ViewData["RouteNumber"] = new SelectList(_context.Routes, "RouteNumber", "RouteNumber", allocate.RouteNumber);
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicles, "VehicleNumber", "VehicleNumber", allocate.VehicleNumber);
            return View(allocate);
        }

        // GET: Allocates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocate = await _context.Allocates.FindAsync(id);
            if (allocate == null)
            {
                return NotFound();
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", allocate.EmpId);
            ViewData["RouteNumber"] = new SelectList(_context.Routes, "RouteNumber", "RouteNumber", allocate.RouteNumber);
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicles, "VehicleNumber", "VehicleNumber", allocate.VehicleNumber);
            return View(allocate);
        }

        // POST: Allocates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocateId,EmpId,VehicleNumber,RouteNumber")] Allocate allocate)
        {
            if (id != allocate.AllocateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocateExists(allocate.AllocateId))
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
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", allocate.EmpId);
            ViewData["RouteNumber"] = new SelectList(_context.Routes, "RouteNumber", "RouteNumber", allocate.RouteNumber);
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicles, "VehicleNumber", "VehicleNumber", allocate.VehicleNumber);
            return View(allocate);
        }

        // GET: Allocates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocate = await _context.Allocates
                .Include(a => a.Employee)
                .Include(a => a.Route)
                .Include(a => a.Vehicle)
                .FirstOrDefaultAsync(m => m.AllocateId == id);
            if (allocate == null)
            {
                return NotFound();
            }

            return View(allocate);
        }

        // POST: Allocates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allocate = await _context.Allocates.FindAsync(id);
            _context.Allocates.Remove(allocate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocateExists(int id)
        {
            return _context.Allocates.Any(e => e.AllocateId == id);
        }
    }
}
