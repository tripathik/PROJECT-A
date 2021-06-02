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
    public class EmployeesController : Controller
    {
        private readonly TMSContext _context;

        public EmployeesController(TMSContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var tMSContext = _context.Employees.Include(e => e.Routes).Include(e => e.Vehicles);
            return View(await tMSContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Routes)
                .Include(e => e.Vehicles)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["RouteNumber"] = new SelectList(_context.Routes, "RouteNumber", "RouteName");
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicles, "VehicleNumber", "VehicleNumber");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,Gender,EmployeeContact,Age,Location,Address,VehicleNumber,RouteNumber")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteNumber"] = new SelectList(_context.Routes, "RouteNumber", "RouteName", employee.RouteNumber);
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicles, "VehicleNumber", "VehicleNumber", employee.VehicleNumber);
            return View(employee);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["RouteNumber"] = new SelectList(_context.Routes, "RouteNumber", "RouteName", employee.RouteNumber);
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicles, "VehicleNumber", "VehicleNumber", employee.VehicleNumber);
            return View(employee);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeName,Gender,EmployeeContact,Age,Location,Address,VehicleNumber,RouteNumber")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["RouteNumber"] = new SelectList(_context.Routes, "RouteNumber", "RouteName", employee.RouteNumber);
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicles, "VehicleNumber", "VehicleNumber", employee.VehicleNumber);
            return View(employee);
        }

   
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Routes)
                .Include(e => e.Vehicles)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
