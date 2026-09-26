using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lgb2410900009_exam.Data;
using Lgb2410900009_exam.Models;

namespace Lgb2410900009_exam.Controllers
{
    public class LgbEmployeesController : Controller
    {
        private readonly LgbDbContext _context;

        public LgbEmployeesController(LgbDbContext context)
        {
            _context = context;
        }

        // GET: LgbEmployees
        public async Task<IActionResult> Index(string searchString)
        {
            var employees = from e in _context.LgbEmployees
                            select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.LgbName.Contains(searchString) ||
                                                 (e.LgbEmail != null && e.LgbEmail.Contains(searchString)) ||
                                                 (e.LgbPhone != null && e.LgbPhone.Contains(searchString)));
            }

            ViewBag.SearchString = searchString;

            return View(await employees.ToListAsync());
        }

        // GET: LgbEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lgbEmployee = await _context.LgbEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lgbEmployee == null)
            {
                return NotFound();
            }

            return View(lgbEmployee);
        }

        // GET: LgbEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LgbEmployees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LgbName,LgbGender,LgbBirthDay,LgbEmail,LgbPhone,LgbActive")] LgbEmployee lgbEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lgbEmployee);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm nhân viên mới thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(lgbEmployee);
        }

        // GET: LgbEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lgbEmployee = await _context.LgbEmployees.FindAsync(id);
            if (lgbEmployee == null)
            {
                return NotFound();
            }
            return View(lgbEmployee);
        }

        // POST: LgbEmployees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LgbName,LgbGender,LgbBirthDay,LgbEmail,LgbPhone,LgbActive")] LgbEmployee lgbEmployee)
        {
            if (id != lgbEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lgbEmployee);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cập nhật nhân viên thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LgbEmployeeExists(lgbEmployee.Id))
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
            return View(lgbEmployee);
        }

        // GET: LgbEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lgbEmployee = await _context.LgbEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lgbEmployee == null)
            {
                return NotFound();
            }

            return View(lgbEmployee);
        }

        // POST: LgbEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lgbEmployee = await _context.LgbEmployees.FindAsync(id);
            if (lgbEmployee != null)
            {
                _context.LgbEmployees.Remove(lgbEmployee);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Xóa nhân viên thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LgbEmployeeExists(int id)
        {
            return _context.LgbEmployees.Any(e => e.Id == id);
        }
    }
}
