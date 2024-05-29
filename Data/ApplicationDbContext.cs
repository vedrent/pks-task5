using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using task5.Models;

namespace task5.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // public DbSet<Student> Students { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}