using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test2.Models;

namespace Test2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Role> Role { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Userlogin> Userlogin { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<SemesterSubject> SemesterSubject { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
