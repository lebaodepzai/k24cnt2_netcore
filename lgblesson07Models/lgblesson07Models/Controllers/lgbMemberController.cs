using lgblesson07Models.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace lgblesson07Models.Controllers
{
    public class lgbMemberController : Controller
    {
        // mock data
        protected List<lgbMember> _members = new List<lgbMember>
        {
            new lgbMember
            {
                lgbMemberId = Guid.NewGuid().ToString(),
                lgbUserName = "lebao2202",
                lgbPassword = "123456",
                lgbFullName = "le gia bao",
                lgbEmail = "lebao2202@gmail.com",
                
            },

            new lgbMember
            {
                lgbMemberId = Guid.NewGuid().ToString(),
                lgbUserName = "tranthib",
                lgbPassword = "123456",
                lgbFullName = "Trần Thị B",
                lgbEmail = "tranthib@gmail.com",
                
            },

            new lgbMember
            {
                lgbMemberId = Guid.NewGuid().ToString(),
                lgbUserName = "levanc",
                lgbPassword = "123456",
                lgbFullName = "Lê Văn C",
                lgbEmail = "levanc@gmail.com",
                
            },

            new lgbMember
            {
                lgbMemberId = Guid.NewGuid().ToString(),
                lgbUserName = "phamthid",
                lgbPassword = "123456",
                lgbFullName = "Phạm Thị D",
                lgbEmail = "phamthid@gmail.com",
               
            },
        };
        public IActionResult Index()
        {
            return View(_members);
        }
        public IActionResult GetMember()
        {
            var member = new lgbMember
            {
                lgbMemberId = Guid.NewGuid().ToString(),
                lgbUserName = "lebao2202",
                lgbPassword = "123",
                lgbFullName = "le gia bao",
                lgbEmail = "lebaoo22022006@gmial.com",
            };
            ViewBag.Member = member;
            return View();
        }
        // dua du lieu dang list ra view
        public IActionResult GetMembers()
        {
            // LAY TU MOCK DATA
            ViewBag.Members = _members;
            return View();
        }
        // GET: create member
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(lgbMember member)
        {
            if (ModelState.IsValid)
            {
                member.lgbMemberId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}
