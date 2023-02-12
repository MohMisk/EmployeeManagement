using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementWeb.Data;
using EmployeeManagementWeb.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using EmployeeManagementWeb.Models;

namespace EmployeeManagementWeb.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var model = new EmployeeIndexViewModel();

            if (_context.Employees == null)
                return Problem("Entity set 'ApplicationDbContext.Employees'  is null.");

            model.EmployeesList = await _context.Employees.ToListAsync();

            return View(model);
        }


        public async Task<IActionResult> Get(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return Json(false);
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return Json(false);
            }
            return Json(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmployeeIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    DepartmentId = model.DepartmentId
                };

                if (model.EmployeeId == 0)
                {
                    _context.Add(employee);
                }
                else
                {
                    employee.EmployeeId = model.EmployeeId;

                    _context.Update(employee);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            //todo: this should be ajax post to handel validation error
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Employees == null)
            {
                return Json(false);
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return Json(true);
        }

    }
}
