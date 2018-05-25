using Microsoft.EntityFrameworkCore;
using StudentenHuis.Models;

namespace SportsStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}