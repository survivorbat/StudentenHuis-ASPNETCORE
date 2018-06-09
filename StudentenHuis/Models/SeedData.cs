using System;
using System.Collections.Generic;
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
            if (context.Meals.Where(e => e.Date.Date.CompareTo(DateTime.Now.Date) >= 0).Count() <= 2)
            {
                ApplicationUser Arno = context.Users.Where(e => e.Firstname == "Arno").FirstOrDefault();
                ApplicationUser Ruud = context.Users.Where(e => e.Firstname == "Ruud").FirstOrDefault();
                ApplicationUser Gitta = context.Users.Where(e => e.Firstname == "Arno").FirstOrDefault();
                ApplicationUser Eefje = context.Users.Where(e => e.Firstname == "Eefje").FirstOrDefault();
                ApplicationUser Robin = context.Users.Where(e => e.Firstname == "Robin").FirstOrDefault();
                ApplicationUser Frank = context.Users.Where(e => e.Firstname == "Frank").FirstOrDefault();

                Meal Pepersteak = new Meal()
                {
                    Title = "Pepersteak met romige saus",
                    Description = "Een twist op de gewone steak met pepersaus, deze steak wordt eerst bedekt met een korst van gemalen peperkorrels en dan gebakken. De steak wordt geserveerd met een romige saus met peper en brandewijn. Genoeg voor twee, of voor 1 als je honger hebt! Bekijk ook de video van dit recept.",
                    Price = 7.35,
                    Cook = Frank,
                    Date = DateTime.Now.AddDays(20),
                    MaxAmountOfGuests = 4
                };
                Pepersteak.Eaters.Add(new MealStudent() { ApplicationUser = Gitta, ApplicationUserId = Gitta.Id, Meal = Pepersteak, MealId = Pepersteak.ID });
                Pepersteak.Eaters.Add(new MealStudent() { ApplicationUser = Eefje, ApplicationUserId = Eefje.Id, Meal = Pepersteak, MealId = Pepersteak.ID });
                Pepersteak.Eaters.Add(new MealStudent() { ApplicationUser = Ruud, ApplicationUserId = Ruud.Id, Meal = Pepersteak, MealId = Pepersteak.ID });

                Meal Pasta1 = new Meal()
                {
                    Title = "Pasta met kip, boursin en spinazie",
                    Description = "Een heerlijk en makkelijk recept voor pasta met kip, champignons en ui in een romige saus van Boursin®, geserveerd met roergebakken verse spinazie.",
                    Price = 0.50,
                    Cook = Ruud,
                    Date = DateTime.Now.AddDays(1),
                    MaxAmountOfGuests = 3
                };
                Pasta1.Eaters.Add(new MealStudent { ApplicationUser = Gitta, ApplicationUserId = Gitta.Id, Meal = Pasta1, MealId = Pasta1.ID });

                Meal Pasta2 = new Meal()
                {
                    Title = "Pasta met boursin en groenten",
                    Description = "Lekker, gezond en gemakkelijk :) perfect voor op kot en eigen toevoegingen zijn altijd welkom in het recept.",
                    Price = 12.35,
                    Cook = Arno,
                    Date = DateTime.Now.AddDays(2),
                    MaxAmountOfGuests = 4
                };

                Pasta2.Eaters.Add(new MealStudent() { ApplicationUser = Robin, ApplicationUserId = Robin.Id, Meal = Pasta2, MealId = Pasta2.ID });
                Pasta2.Eaters.Add(new MealStudent() { ApplicationUser = Ruud, ApplicationUserId = Ruud.Id, Meal = Pasta2, MealId = Pasta2.ID});

                Meal Aardbeien = new Meal()
                {
                    Title = "Aardbeien tompouce",
                    Description = "Een eenvoudig te maken dubbellaagse tompoes met verse aardbeien, een heerlijke variatie op de 'gewone' tompoes. Gemakkelijk door gebruik van bladerdeeg en instant banketbakkersroom, maar ziet er fantastisch professioneel uit! Wel dezelfde dag nog opeten, maar dat is vast geen probleem.",
                    Price = 2.95,
                    Cook = Eefje,
                    Date = DateTime.Now.AddDays(3),
                    MaxAmountOfGuests = 1
                };
                Aardbeien.Eaters.Add(new MealStudent() { Meal = Aardbeien, MealId = Aardbeien.ID, ApplicationUser = Gitta, ApplicationUserId = Gitta.Id });

                Meal Pizza = new Meal()
                {
                    Title = "Domino's Pizza",
                    Description = "Magherita",
                    Price = 3.29,
                    Cook = Arno,
                    Date = DateTime.Now.AddDays(4),
                    MaxAmountOfGuests = 6
                };
                Meal Pizza2 = new Meal()
                {
                    Title = "Domino's Pizza",
                    Description = "Magherita",
                    Price = 3.29,
                    Cook = Arno,
                    Date = DateTime.Now.AddDays(6),
                    MaxAmountOfGuests = 3
                };
                Meal Pizza3 = new Meal()
                {
                    Title = "Domino's Pizza",
                    Description = "Magherita",
                    Price = 3.29,
                    Cook = Arno,
                    Date = DateTime.Now.AddDays(5),
                    MaxAmountOfGuests = 10
                };
                Meal Pizza4 = new Meal()
                {
                    Title = "Domino's Pizza",
                    Description = "Magherita",
                    Price = 3.90,
                    Cook = Arno,
                    Date = DateTime.Now.AddDays(7),
                    MaxAmountOfGuests = 10
                };

                context.Meals.AddRange(Pizza, Pasta1, Pasta2, Aardbeien, Pepersteak, Pizza2, Pizza3);
                context.SaveChanges();
            }
        }
        public static async Task AddUser(UserManager<ApplicationUser> UM, ApplicationUser student)
        {
            var result = await UM.CreateAsync(student, "Test123#");
        }
    }
}