using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace StudentenHuis.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            ApplicationDbContext context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            UserManager<ApplicationUser> UM = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser student = new ApplicationUser()
            {
                UserName = "Arno",
                Email = "a.broeders@avans.nl",
                PhoneNumber = "06-827492",
                Firstname = "Arno",
                Lastname = "Broeders",
            };

            if (!context.Meals.Any())
            {
                addUser(UM, student).Wait();
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
        public static async Task addUser(UserManager<ApplicationUser> UM, ApplicationUser student)
        {
            var result = await UM.CreateAsync(student, "super123@#!!!SSS");
            Console.WriteLine(result);
            Console.WriteLine(result.Succeeded);
        }
    }
}