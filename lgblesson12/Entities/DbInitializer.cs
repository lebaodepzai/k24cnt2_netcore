using System;
using System.Linq;
using lgblesson12.Models;

namespace lgblesson12.Entities
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Categories.Any())
            {
                return; // DB has been seeded
            }

            // Seed Categories
            var categories = new Category[]
            {
                new Category { Name = "Áo nam", Status = 1, CreatedDate = DateTime.Now },
                new Category { Name = "Túi xách", Status = 1, CreatedDate = DateTime.Now },
                new Category { Name = "Giày dép", Status = 1, CreatedDate = DateTime.Now }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            // Seed Banners
            var banners = new Banner[]
            {
                new Banner { Name = "Microsoft Azure Banner", Image = "banner1.png", Description = "Learn how Microsoft Azure cloud platform allows you to build, deploy and scale web apps.", CreatedDate = DateTime.Now, Status = 1 },
                new Banner { Name = "Summer Collection", Image = "banner2.png", Description = "New arrival collection for summer 2026", CreatedDate = DateTime.Now, Status = 1 }
            };
            context.Banners.AddRange(banners);
            context.SaveChanges();

            // Seed Products
            var products = new Product[]
            {
                new Product { Name = "Demo product 12", Image = "product1.jpg", Price = 5000000, SalePrice = 4500000, Status = 1, Descriptions = "he llo", CategoryId = categories[1].Id, CreatedDate = DateTime.Now },
                new Product { Name = "Demo Product 23", Image = "product2.jpg", Price = 5000000, SalePrice = 4500000, Status = 1, Descriptions = "Demo sesc", CategoryId = categories[1].Id, CreatedDate = DateTime.Now },
                new Product { Name = "Demo prduct 34", Image = "product3.jpg", Price = 5000000, SalePrice = 4500000, Status = 1, Descriptions = "Demo desc 12", CategoryId = categories[1].Id, CreatedDate = DateTime.Now },
                new Product { Name = "Áo sơ mi nam cao cấp", Image = "product4.jpg", Price = 450000, SalePrice = 390000, Status = 1, Descriptions = "Áo sơ mi chất liệu cotton thoáng mát", CategoryId = categories[0].Id, CreatedDate = DateTime.Now }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            // Seed StdClasses
            var stdClasses = new StdClass[]
            {
                new StdClass { ClassName = "K24CNT2" },
                new StdClass { ClassName = "K24CNT1" },
                new StdClass { ClassName = "K23CNT1" }
            };
            context.StdClasses.AddRange(stdClasses);
            context.SaveChanges();

            // Seed Students
            var students = new Student[]
            {
                new Student { StudentName = "Lê Bảo", StudentEmail = "lebao@gmail.com", StudentPhone = "0987654321", StudentAddress = "Hà Nội", StudentAvatar = "avatar1.png", StudentBirthday = new DateTime(2003, 5, 15), ClassId = stdClasses[0].Id },
                new Student { StudentName = "Nguyễn Văn A", StudentEmail = "nguyenvana@gmail.com", StudentPhone = "0912345678", StudentAddress = "Hải Phòng", StudentAvatar = "avatar2.png", StudentBirthday = new DateTime(2003, 8, 20), ClassId = stdClasses[0].Id }
            };
            context.Students.AddRange(students);
            context.SaveChanges();

            // Seed Subjects
            var subjects = new Subjects[]
            {
                new Subjects { SubjectName = "Lập trình ASP.NET Core MVC" },
                new Subjects { SubjectName = "Cơ sở dữ liệu SQL Server" },
                new Subjects { SubjectName = "Lập trình C# Nâng cao" }
            };
            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            // Seed Marks
            var marks = new Marks[]
            {
                new Marks { SubjectId = subjects[0].Id, StudentId = students[0].Id, Score = 9.5f },
                new Marks { SubjectId = subjects[1].Id, StudentId = students[0].Id, Score = 8.5f },
                new Marks { SubjectId = subjects[0].Id, StudentId = students[1].Id, Score = 8.0f }
            };
            context.Marks.AddRange(marks);
            context.SaveChanges();
        }
    }
}
