using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Registration.Shared.Models;

namespace Registration.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
               .HasOne(c => c.DependentCourse)
               .WithMany()
               .HasForeignKey(e => e.DependentOnCourseID);

            modelBuilder.Entity<RegistrationTable>()
                .Property(r => r.RegistrationTime)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Student", NormalizedName = "Student".ToUpper() });
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CoursePerLecturer> CoursePerLecturers { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<DayPerSlot> DayPerSlots { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RegistrationTable> Registrations { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Student> Students { get; set; }


    }
}
