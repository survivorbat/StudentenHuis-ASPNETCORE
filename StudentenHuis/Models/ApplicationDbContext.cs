using Microsoft.EntityFrameworkCore;
using StudentenHuis.Models;

namespace StudentenHuis.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>().HasOne(e => e.Cook);
            modelBuilder.Entity<Meal>().HasMany(e => e.Eaters);

            modelBuilder.Entity<Student>().HasMany(e => e.MealsAsEater);
            modelBuilder.Entity<Student>().HasMany(e => e.MealsAsCook);
        }
    }
}