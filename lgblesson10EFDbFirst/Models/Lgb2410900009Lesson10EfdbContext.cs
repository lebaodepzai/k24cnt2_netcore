using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LgbLesson10EFDbFirst.Models;

public partial class Lgb2410900009Lesson10EfdbContext : DbContext
{
    public Lgb2410900009Lesson10EfdbContext()
    {
    }

    public Lgb2410900009Lesson10EfdbContext(DbContextOptions<Lgb2410900009Lesson10EfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LgbMember> LgbMembers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQL2019;Database=Lgb2410900009Lesson10EFDb;uid=sa;pwd=1234$; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LgbMember>(entity =>
        {
            entity.ToTable("LgbMember");

            entity.Property(e => e.LgbEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LgbFullName).HasMaxLength(50);
            entity.Property(e => e.LgbPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LgbPhone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.LgbUserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
