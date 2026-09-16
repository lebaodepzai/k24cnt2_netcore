using Microsoft.AspNetCore.Mvc;
using LgbLesson08Models.Models;

namespace LgbLesson08Models.Controllers
{
    public class LgbMemberController : Controller
    {
        // Danh sách dữ liệu giả lập thành viên (Mock Data)
        private static List<LgbMember> _members = new List<LgbMember>()
        {
            new LgbMember
            {
                LgbMemberId = "MEM001",
                LgbUserName = "lebao",
                LgbPassword = "Password123!",
                LgbFullName = "Lê Bảo",
                LgbEmail = "lebao@gmail.com",
                LgbAge = 20
            },
            new LgbMember
            {
                LgbMemberId = "MEM002",
                LgbUserName = "tranthib",
                LgbPassword = "SecurePass456#",
                LgbFullName = "Trần Thị B",
                LgbEmail = "tranthib@gmail.com",
                LgbAge = 21
            },
            new LgbMember
            {
                LgbMemberId = "MEM003",
                LgbUserName = "nguyenvanc",
                LgbPassword = "Pass789Word!",
                LgbFullName = "Nguyễn Văn C",
                LgbEmail = "nguyenvanc@gmail.com",
                LgbAge = 22
            }
        };

        // GET: /LgbMember/ or /LgbMember/Index
        public IActionResult Index()
        {
            return View(_members);
        }

        // GET: /LgbMember/LgbCreate
        public IActionResult LgbCreate()
        {
            var newMember = new LgbMember
            {
                LgbMemberId = "MEM00" + (_members.Count + 1)
            };
            return View(newMember);
        }

        // POST: /LgbMember/LgbCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LgbCreate(LgbMember member)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(member.LgbMemberId))
                {
                    member.LgbMemberId = Guid.NewGuid().ToString();
                }
                _members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: /LgbMember/LgbDetails/id
        public IActionResult LgbDetails(string id)
        {
            var member = _members.FirstOrDefault(m => m.LgbMemberId == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: /LgbMember/LgbEdit/id
        public IActionResult LgbEdit(string id)
        {
            var member = _members.FirstOrDefault(m => m.LgbMemberId == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: /LgbMember/LgbEdit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LgbEdit(string id, LgbMember member)
        {
            var existingMember = _members.FirstOrDefault(m => m.LgbMemberId == id);
            if (existingMember == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingMember.LgbUserName = member.LgbUserName;
                existingMember.LgbPassword = member.LgbPassword;
                existingMember.LgbFullName = member.LgbFullName;
                existingMember.LgbEmail = member.LgbEmail;
                existingMember.LgbAge = member.LgbAge;

                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: /LgbMember/LgbDelete/id
        public IActionResult LgbDelete(string id)
        {
            var member = _members.FirstOrDefault(m => m.LgbMemberId == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: /LgbMember/LgbDelete/id
        [HttpPost, ActionName("LgbDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult LgbDeleteConfirmed(string id)
        {
            var member = _members.FirstOrDefault(m => m.LgbMemberId == id);
            if (member != null)
            {
                _members.Remove(member);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
