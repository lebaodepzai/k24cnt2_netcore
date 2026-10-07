using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LgbLesson10EFDbFirst.Models;

namespace LgbLesson10EFDbFirst.Controllers
{
    public class LgbMembersController : Controller
    {
        private readonly Lgb2410900009Lesson10EfdbContext _context;

        public LgbMembersController(Lgb2410900009Lesson10EfdbContext context)
        {
            _context = context;
        }

        // GET: LgbMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.LgbMembers.ToListAsync());
        }

        // GET: LgbMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lgbMember = await _context.LgbMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lgbMember == null)
            {
                return NotFound();
            }

            return View(lgbMember);
        }

        // GET: LgbMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LgbMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LgbUserName,LgbPassword,LgbFullName,LgbEmail,LgbPhone,LgbStatus")] LgbMember lgbMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lgbMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lgbMember);
        }

        // GET: LgbMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lgbMember = await _context.LgbMembers.FindAsync(id);
            if (lgbMember == null)
            {
                return NotFound();
            }
            return View(lgbMember);
        }

        // POST: LgbMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,LgbUserName,LgbPassword,LgbFullName,LgbEmail,LgbPhone,LgbStatus")] LgbMember lgbMember)
        {
            if (id != lgbMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lgbMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LgbMemberExists(lgbMember.Id))
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
            return View(lgbMember);
        }

        // GET: LgbMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lgbMember = await _context.LgbMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lgbMember == null)
            {
                return NotFound();
            }

            return View(lgbMember);
        }

        // POST: LgbMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var lgbMember = await _context.LgbMembers.FindAsync(id);
            if (lgbMember != null)
            {
                _context.LgbMembers.Remove(lgbMember);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LgbMemberExists(long id)
        {
            return _context.LgbMembers.Any(e => e.Id == id);
        }
    }
}
