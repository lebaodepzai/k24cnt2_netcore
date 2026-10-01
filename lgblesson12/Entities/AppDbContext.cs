using Microsoft.EntityFrameworkCore;
using lgblesson12.Models;

namespace lgblesson12.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Banner> Banners { get; set; } = null!;
        public DbSet<StdClass> StdClasses { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Subjects> Subjects { get; set; } = null!;
        public DbSet<Marks> Marks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for Marks
            modelBuilder.Entity<Marks>()
                .HasKey(m => new { m.SubjectId, m.StudentId });

            // Unique constraints
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentEmail)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentPhone)
                .IsUnique();

            modelBuilder.Entity<Subjects>()
                .HasIndex(sb => sb.SubjectName)
                .IsUnique();

            // Relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.StdClass)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Marks>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Marks>()
                .HasOne(m => m.Subject)
                .WithMany(sb => sb.Marks)
                .HasForeignKey(m => m.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
