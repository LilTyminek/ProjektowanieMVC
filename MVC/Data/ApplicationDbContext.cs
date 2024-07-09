using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Student> Students { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Enrollment> Enrollments { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Course> Courses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            // Konfiguracja tabel Student, Enrollment oraz Course
            builder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");
                entity.HasKey(e => e.ID);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.FirstMidName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.EnrollmentDate).IsRequired();
            });

            builder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");
                entity.HasKey(e => e.EnrollmentID);
                entity.HasOne(e => e.Student)
                    .WithMany(s => s.Enrollments)
                    .HasForeignKey(e => e.StudentID);
                entity.HasOne(e => e.Course)
                    .WithMany(c => c.Enrollments)
                    .HasForeignKey(e => e.CourseID);
            });

            builder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");
                entity.HasKey(e => e.CourseID);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Credits).IsRequired();
            });

        }
    }
}
