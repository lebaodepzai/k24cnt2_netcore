using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lgb2410900009_exam.Data;
using Lgb2410900009_exam.Models;

namespace Lgb2410900009_exam.Controllers
{
    public class LgbStudentsController : Controller
    {
        private readonly LgbDbContext _context;

        public LgbStudentsController(LgbDbContext context)
        {
            _context = context;
        }

        // GET: LgbStudents
        public async Task<IActionResult> Index(string searchString, string genderFilter)
        {
            var students = from s in _context.LgbStudents
                           select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LgbName.Contains(searchString) ||
                                               (s.LgbEmail != null && s.LgbEmail.Contains(searchString)) ||
                                               (s.LgbPhone != null && s.LgbPhone.Contains(searchString)));
            }

            if (!string.IsNullOrEmpty(genderFilter))
            {
                students = students.Where(s => s.LgbGender == genderFilter);
            }

            ViewBag.SearchString = searchString;
            ViewBag.GenderFilter = genderFilter;

            return View(await students.ToListAsync());
        }

        // GET: LgbStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lgbStudent = await _context.LgbStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lgbStudent == null)
            {
                return NotFound();
            }

            return View(lgbStudent);
        }

        // GET: LgbStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LgbStudents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LgbName,LgbGender,LgbBirthDay,LgbEmail,LgbPhone,LgbAddress,LgbActive")] LgbStudent lgbStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lgbStudent);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm sinh viên mới thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(lgbStudent);
        }

        // GET: LgbStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lgbStudent = await _context.LgbStudents.FindAsync(id);
            if (lgbStudent == null)
            {
                return NotFound();
            }
            return View(lgbStudent);
        }

        // POST: LgbStudents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LgbName,LgbGender,LgbBirthDay,LgbEmail,LgbPhone,LgbAddress,LgbActive")] LgbStudent lgbStudent)
        {
            if (id != lgbStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lgbStudent);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cập nhật thông tin sinh viên thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LgbStudentExists(lgbStudent.Id))
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
            return View(lgbStudent);
        }

        // GET: LgbStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lgbStudent = await _context.LgbStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lgbStudent == null)
            {
                return NotFound();
            }

            return View(lgbStudent);
        }

        // POST: LgbStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lgbStudent = await _context.LgbStudents.FindAsync(id);
            if (lgbStudent != null)
            {
                _context.LgbStudents.Remove(lgbStudent);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Xóa sinh viên thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LgbStudentExists(int id)
        {
            return _context.LgbStudents.Any(e => e.Id == id);
        }
    }
}
