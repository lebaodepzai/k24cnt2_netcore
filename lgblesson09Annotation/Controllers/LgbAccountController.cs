using Microsoft.AspNetCore.Mvc;
using lgblesson09Annotation.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace lgblesson09Annotation.Controllers
{
    public class LgbAccountController : Controller
    {
        // Danh sách tài khoản mẫu lưu tạm trong bộ nhớ
        private static List<LgbAccount> _accounts = new List<LgbAccount>
        {
            new LgbAccount
            {
                Id = 1,
                FullName = "Lê Bảo",
                Email = "lebao@gmail.com",
                Phone = "0987654321",
                Password = "Password123",
                ConfirmPassword = "Password123",
                Age = 20,
                Gender = "Nam",
                BirthDate = new DateTime(2004, 5, 15),
                FacebookUrl = "https://facebook.com/lebao",
                IsActive = true
            },
            new LgbAccount
            {
                Id = 2,
                FullName = "Phạm Tiến Tuân",
                Email = "pttuan@gmail.com",
                Phone = "0912345678",
                Password = "Password123",
                ConfirmPassword = "Password123",
                Age = 25,
                Gender = "Nam",
                BirthDate = new DateTime(1999, 8, 20),
                FacebookUrl = "https://facebook.com/pttuan",
                IsActive = true
            }
        };

        // GET: /LgbAccount/Index
        public IActionResult Index()
        {
            return View(_accounts);
        }

        // GET: /LgbAccount/Register
        public IActionResult Register()
        {
            var model = new LgbAccount();
            return View(model);
        }

        // POST: /LgbAccount/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(LgbAccount model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem email đã tồn tại hay chưa
                if (_accounts.Any(a => a.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("Email", "Địa chỉ Email này đã được đăng ký tài khoản!");
                    return View(model);
                }

                model.Id = _accounts.Count > 0 ? _accounts.Max(a => a.Id) + 1 : 1;
                _accounts.Add(model);

                TempData["SuccessMessage"] = "Đăng ký tài khoản thành công!";
                return RedirectToAction(nameof(Index));
            }

            // ModelState không hợp lệ, trả về view kèm các thông báo lỗi
            return View(model);
        }

        // GET: /LgbAccount/Details/1
        public IActionResult Details(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // GET: /LgbAccount/Edit/1
        public IActionResult Edit(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: /LgbAccount/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LgbAccount model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var account = _accounts.FirstOrDefault(a => a.Id == id);
                if (account == null)
                {
                    return NotFound();
                }

                account.FullName = model.FullName;
                account.Email = model.Email;
                account.Phone = model.Phone;
                account.Age = model.Age;
                account.Gender = model.Gender;
                account.BirthDate = model.BirthDate;
                account.FacebookUrl = model.FacebookUrl;
                account.IsActive = model.IsActive;

                TempData["SuccessMessage"] = "Cập nhật thông tin tài khoản thành công!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
