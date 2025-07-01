using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LOGINSYSTEM.Models;

public partial class LoginsystemContext : DbContext
{
    public LoginsystemContext()
    {
    }

    public LoginsystemContext(DbContextOptions<LoginsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

  //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=LOGINSYSTEM;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserDeta__1788CC4C2EBCB742");

            entity.ToTable("UserDetail");

            entity.HasIndex(e => e.Email, "UQ__UserDeta__A9D10534F34623D1").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("PK__UserLogi__4DDA28188E21EF5D");

            entity.ToTable("UserLogin");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserLogin__UserI__72C60C4A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
