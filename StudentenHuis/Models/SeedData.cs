using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace StudentenHuis.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            ApplicationDbContext context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            Student student = new Student()
            {
                Firstname = "Arno",
                Lastname = "Broeders",
                Email = "a.broeders@avans.nl",
                Telephonenumber = "06827492"
            };
            if (!context.Students.Any())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
            if (!context.Meals.Any())
            {
                context.Meals.AddRange(
                new Meal()
                {
                    Title = "Shoarma",
                    Description = "Van dat zaakje op de hoek!",
                    Price = 7.35,
                    Cook = student,
                    Date = new DateTime(2018, 1, 4),
                    MaxAmountOfGuests = 2
                },
                new Meal()
                {
                    Title = "Avans koffie",
                    Description = "Lekker koffieleuten",
                    Price = 0.50,
                    Cook = student,
                    Date = new DateTime(2018, 1, 3),
                    MaxAmountOfGuests = 8
                },
                new Meal()
                {
                    Title = "Spaghetti",
                    Description = "Erg lekker spaghetti bord",
                    Price = 2.35,
                    Cook = student,
                    Date = new DateTime(2018, 1, 2),
                    MaxAmountOfGuests = 10
                },
                new Meal()
                {
                    Title = "Pizza",
                    Description = "Van domino's",
                    Price = 2.95,
                    Cook = student,
                    Date = new DateTime(2018, 1, 1),
                    MaxAmountOfGuests = 10
                }
                );
                context.SaveChanges();
            }
        }
    }
}