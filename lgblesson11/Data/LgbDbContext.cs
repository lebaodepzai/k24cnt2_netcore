using Microsoft.EntityFrameworkCore;
using Lgb2410900009_exam.Models;
using System;

namespace Lgb2410900009_exam.Data
{
    public class LgbDbContext : DbContext
    {
        public LgbDbContext(DbContextOptions<LgbDbContext> options) : base(options)
        {
        }

        public DbSet<LgbEmployee> LgbEmployees { get; set; } = null!;
        public DbSet<LgbStudent> LgbStudents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data for LgbEmployee
            modelBuilder.Entity<LgbEmployee>().HasData(
                new LgbEmployee
                {
                    Id = 1,
                    LgbName = "Lê Gia Bảo",
                    LgbGender = "Nam",
                    LgbBirthDay = new DateTime(2004, 5, 15),
                    LgbEmail = "lebaoo22022006@gmail.com",
                    LgbPhone = "0912345678",
                    LgbActive = true
                },
                new LgbEmployee
                {
                    Id = 2,
                    LgbName = "Nguyễn Thị Bảo",
                    LgbGender = "Nữ",
                    LgbBirthDay = new DateTime(2004, 8, 20),
                    LgbEmail = "nguyenthibao@gmail.com",
                    LgbPhone = "0987654321",
                    LgbActive = true
                },
                new LgbEmployee
                {
                    Id = 3,
                    LgbName = "Trần Văn An",
                    LgbGender = "Nam",
                    LgbBirthDay = new DateTime(2003, 12, 10),
                    LgbEmail = "tranvanan@gmail.com",
                    LgbPhone = "0933445566",
                    LgbActive = false
                }
            );

            // Seed Data for LgbStudent
            modelBuilder.Entity<LgbStudent>().HasData(
                new LgbStudent
                {
                    Id = 1,
                    LgbName = "Lê Bảo Giang",
                    LgbGender = "Nam",
                    LgbBirthDay = new DateTime(2004, 5, 15),
                    LgbEmail = "lgb2410900009@student.edu.vn",
                    LgbPhone = "0912345678",
                    LgbAddress = "Hà Nội",
                    LgbActive = true
                },
                new LgbStudent
                {
                    Id = 2,
                    LgbName = "Nguyễn Văn Bình",
                    LgbGender = "Nam",
                    LgbBirthDay = new DateTime(2004, 9, 12),
                    LgbEmail = "nguyenvanbinh@gmail.com",
                    LgbPhone = "0981112233",
                    LgbAddress = "Hải Phòng",
                    LgbActive = true
                },
                new LgbStudent
                {
                    Id = 3,
                    LgbName = "Hoàng Thảo My",
                    LgbGender = "Nữ",
                    LgbBirthDay = new DateTime(2004, 11, 5),
                    LgbEmail = "hoangthaomy@gmail.com",
                    LgbPhone = "0965554433",
                    LgbAddress = "Nam Định",
                    LgbActive = true
                }
            );
        }
    }
}
