using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lgblesson12.Entities;
using lgblesson12.Models;

namespace lgblesson12.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Students.Include(s => s.StdClass);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .Include(s => s.StdClass)
                .Include(s => s.Marks!)
                .ThenInclude(m => m.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.StdClasses, "Id", "ClassName");
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentName,StudentEmail,StudentPhone,StudentAddress,StudentBirthday,ClassId")] Student student)
        {
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var fileName = file.FileName;
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var path = Path.Combine(folderPath, fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                student.StudentAvatar = fileName;
            }

            // Check email and phone uniqueness
            if (_context.Students.Any(s => s.StudentEmail == student.StudentEmail))
            {
                ModelState.AddModelError("StudentEmail", "Email đã tồn tại trên hệ thống");
            }
            if (_context.Students.Any(s => s.StudentPhone == student.StudentPhone))
            {
                ModelState.AddModelError("StudentPhone", "Số điện thoại đã tồn tại trên hệ thống");
            }

            if (string.IsNullOrEmpty(student.StudentAvatar))
            {
                ModelState.AddModelError("StudentAvatar", "Vui lòng chọn ảnh đại diện");
            }

            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.StdClasses, "Id", "ClassName", student.ClassId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            ViewData["ClassId"] = new SelectList(_context.StdClasses, "Id", "ClassName", student.ClassId);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentName,StudentEmail,StudentPhone,StudentAddress,StudentAvatar,StudentBirthday,ClassId")] Student student)
        {
            if (id != student.Id) return NotFound();

            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var fileName = file.FileName;
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var path = Path.Combine(folderPath, fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                student.StudentAvatar = fileName;
            }

            // Check email & phone uniqueness excluding current student
            if (_context.Students.Any(s => s.StudentEmail == student.StudentEmail && s.Id != id))
            {
                ModelState.AddModelError("StudentEmail", "Email đã trùng với sinh viên khác");
            }
            if (_context.Students.Any(s => s.StudentPhone == student.StudentPhone && s.Id != id))
            {
                ModelState.AddModelError("StudentPhone", "Số điện thoại đã trùng với sinh viên khác");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existing = await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
                    if (existing != null && string.IsNullOrEmpty(student.StudentAvatar))
                    {
                        student.StudentAvatar = existing.StudentAvatar;
                    }
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.StdClasses, "Id", "ClassName", student.ClassId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .Include(s => s.StdClass)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
