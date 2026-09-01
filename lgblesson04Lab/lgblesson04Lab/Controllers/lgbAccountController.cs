using lgblesson04Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace lgblesson04Lab.Controllers
{
    public class lgbAccountController : Controller
    {
        private readonly List<lgbAccount> lgbAccounts = new()
        {
                    new lgbAccount
                    {
                        Id = 1,
                        Name = "Nguyễn Văn An",
                        Email = "nguvenvanan@example.com",
                        Phone = "0901234567",
                        Avatar = "/images/1.jpg",
                        Address = "123 Lê Lợi, Phường Bến Thành, Quận 1, TP. Hồ Chí Minh",
                        Bio = "Lập trình viên backend đam mê công nghệ.",
                        Gender = 1, // 1: Nam
                        Brithay = new DateTime(1995, 5, 15)
                    },
                    new lgbAccount
                    {
                        Id = 2,
                        Name = "Trần Thị Bích",
                        Email = "tranthibich@example.com",
                        Phone = "0912345678",
                        Avatar = "/images/2.png",
                        Address = "456 Hoàng Hoa Thám, Phường 7, Quận Bình Thạnh, TP. Hồ Chí Minh",
                        Bio = "Chuyên viên thiết kế UI/UX.",
                        Gender = 0, // 0: Nữ
                        Brithay = new DateTime(1998, 8, 22)
                    },
                    new lgbAccount
                    {
                        Id = 3,
                        Name = "Lê Hoàng Cường",
                        Email = "lehoangcuong@example.com",
                        Phone = "0923456789",
                        Avatar = "/images/3.jpg",
                        Address = "789 Cầu Giấy, Phường Dịch Vọng, Quận Cầu Giấy, Hà Nội",
                        Bio = "Quản lý dự án phần mềm.",
                        Gender = 1,
                        Brithay = new DateTime(1992, 11, 10)
                    },
                    new lgbAccount
                    {
                        Id = 4,
                        Name = "Phạm Dung Dung",
                        Email = "phamdungdung@example.com",
                        Phone = "0934567890",
                        Avatar = "/images/4.jpg",
                        Address = "101 Nguyễn Văn Linh, Phường Tân Phong, Quận 7, TP. Hồ Chí Minh",
                        Bio = "Yêu thích du lịch và đọc sách.",
                        Gender = 0,
                        Brithay = new DateTime(2000, 3, 5)
                    },
                    new lgbAccount
                    {
                        Id = 5,
                        Name = "Vũ Minh Đức",
                        Email = "vuminhduc@example.com",
                        Phone = "0945678901",
                        Avatar = "/images/1.jpg",
                        Address = "202 Trần Phú, Phường Hải Châu 1, Quận Hải Châu, Đà Nẵng",
                        Bio = "Kỹ sư DevOps.",
                        Gender = 1,
                        Brithay = new DateTime(1996, 12, 30)
                    }
                

        };
        public IActionResult lgbIndex()
        {

            ViewBag.lgbAccounts = lgbAccounts;
            return View();
        }
        [Route("ho-so-cua-toi",Name = "lgbProfile")]
        public IActionResult lgbProfile(int? id)
        {
            lgbAccount lgbAccount = new lgbAccount
            {
                Id = 5,
                Name = "Vũ Minh Đức",
                Email = "vuminhduc@example.com",
                Phone = "0945678901",
                Avatar = "/images/1.jpg",
                Address = "202 Trần Phú, Phường Hải Châu 1, Quận Hải Châu, Đà Nẵng",
                Bio = "Kỹ sư DevOps.",
                Gender = 1,
                Brithay = new DateTime(1996, 12, 30)
            };
            if (id != null)
             lgbAccount = lgbAccounts.FirstOrDefault(x => x.Id == id);
            ViewBag.lgbAccount = lgbAccount;
            return View();
        }
    }
}
