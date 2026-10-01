using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lgblesson12.Entities;
using lgblesson12.Models;

namespace lgblesson12.Controllers
{
    public class BannerController : Controller
    {
        private readonly AppDbContext _context;

        public BannerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Banner
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banners.ToListAsync());
        }

        // GET: Banner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var banner = await _context.Banners.FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null) return NotFound();

            return View(banner);
        }

        // GET: Banner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Status")] Banner banner)
        {
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var fileName = file.FileName;
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Banner");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var path = Path.Combine(folderPath, fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                banner.Image = fileName;
            }

            if (ModelState.IsValid)
            {
                banner.CreatedDate = DateTime.Now;
                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Banner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var banner = await _context.Banners.FindAsync(id);
            if (banner == null) return NotFound();

            return View(banner);
        }

        // POST: Banner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Description,Status")] Banner banner)
        {
            if (id != banner.Id) return NotFound();

            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var fileName = file.FileName;
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Banner");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var path = Path.Combine(folderPath, fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                banner.Image = fileName;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existing = await _context.Banners.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                    if (existing != null)
                    {
                        banner.CreatedDate = existing.CreatedDate;
                        if (string.IsNullOrEmpty(banner.Image))
                        {
                            banner.Image = existing.Image;
                        }
                    }
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerExists(banner.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Banner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var banner = await _context.Banners.FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null) return NotFound();

            return View(banner);
        }

        // POST: Banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner != null)
            {
                _context.Banners.Remove(banner);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
            return _context.Banners.Any(e => e.Id == id);
        }
    }
}
