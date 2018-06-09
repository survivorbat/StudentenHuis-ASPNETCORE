using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {
                
        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealStudent> MealStudents { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MealStudent>().HasKey(t => new { t.MealId, t.ApplicationUserId });
            modelBuilder.Entity<ApplicationUser>().HasMany<MealStudent>(e => e.MealsAsEater).WithOne(e => e.ApplicationUser);

            modelBuilder.Entity<Meal>().HasOne<ApplicationUser>(e => e.Cook).WithMany(e => e.MealsAsCook);
            modelBuilder.Entity<Meal>().HasMany<MealStudent>(e => e.Eaters).WithOne(e => e.Meal);
            modelBuilder.Entity<Meal>().HasIndex(e => e.Date).IsUnique();
        }

        protected UserManager<ApplicationUser> UserManager { get; set; }
    }
}
