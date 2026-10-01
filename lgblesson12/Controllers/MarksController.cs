using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lgblesson12.Entities;
using lgblesson12.Models;

namespace lgblesson12.Controllers
{
    public class MarksController : Controller
    {
        private readonly AppDbContext _context;

        public MarksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Marks.Include(m => m.Student).Include(m => m.Subject);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Marks/Details?subjectId=1&studentId=1
        public async Task<IActionResult> Details(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null) return NotFound();

            var marks = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.SubjectId == subjectId && m.StudentId == studentId);

            if (marks == null) return NotFound();

            return View(marks);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentName");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName");
            return View();
        }

        // POST: Marks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,StudentId,Score")] Marks marks)
        {
            if (_context.Marks.Any(m => m.SubjectId == marks.SubjectId && m.StudentId == marks.StudentId))
            {
                ModelState.AddModelError("", "Sinh viên này đã có điểm môn học này!");
            }

            if (ModelState.IsValid)
            {
                _context.Add(marks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentName", marks.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", marks.SubjectId);
            return View(marks);
        }

        // GET: Marks/Edit?subjectId=1&studentId=1
        public async Task<IActionResult> Edit(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null) return NotFound();

            var marks = await _context.Marks.FindAsync(subjectId, studentId);
            if (marks == null) return NotFound();

            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentName", marks.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", marks.SubjectId);
            return View(marks);
        }

        // POST: Marks/Edit?subjectId=1&studentId=1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int subjectId, int studentId, [Bind("SubjectId,StudentId,Score")] Marks marks)
        {
            if (subjectId != marks.SubjectId || studentId != marks.StudentId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarksExists(marks.SubjectId, marks.StudentId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentName", marks.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", marks.SubjectId);
            return View(marks);
        }

        // GET: Marks/Delete?subjectId=1&studentId=1
        public async Task<IActionResult> Delete(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null) return NotFound();

            var marks = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.SubjectId == subjectId && m.StudentId == studentId);

            if (marks == null) return NotFound();

            return View(marks);
        }

        // POST: Marks/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int subjectId, int studentId)
        {
            var marks = await _context.Marks.FindAsync(subjectId, studentId);
            if (marks != null)
            {
                _context.Marks.Remove(marks);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MarksExists(int subjectId, int studentId)
        {
            return _context.Marks.Any(e => e.SubjectId == subjectId && e.StudentId == studentId);
        }
    }
}
