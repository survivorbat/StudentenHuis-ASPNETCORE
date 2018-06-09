using Moq;
using StudentenHuis.Controllers;
using StudentenHuis.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudentenHuisTests
{
    public class MealControllerTests
    {
        [Fact]
        public void IndexReturnsListOfItems()
        {
            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            Mock<IUserRepository> UserMock = new Mock<IUserRepository>();

            ApplicationUser User = new ApplicationUser() { Firstname = "Arno", Lastname = "Broeders" };
            Meal Meal5 = new Meal()
            {
                ID = 5,
                Cook = User,
                Date = DateTime.Now.AddDays(2)
            };
            User.MealsAsCook.Add(Meal5);
            mock.Setup(m => m.Meals).Returns(new List<Meal>()
            {
                new Meal() { ID=0, Title = "Prachtmaaltijd", Description = "Prachtbeschrijving", Price = 0.25, Date = DateTime.Now.AddDays(4)},
                new Meal() { ID=1, Title = "Supermaaltijd", Description = "Superbeschrijving", Price = 0.85, Date = DateTime.Now.AddDays(2)},
                new Meal() { ID=2, Title = "Machtige maaltijd", Description = "Machtige beschrijving", Price = 0.55, Date = DateTime.Now.AddDays(7)},
                new Meal() { ID=3, Title = "Z maaltijd", Description = "Z beschrijving", Price = 0.45, Date = DateTime.Now.AddDays(5)},
                new Meal() { ID=4, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(-1)},
                Meal5
            });

            MealController meals = new MealController(mock.Object, UserMock.Object);
            List<Meal> list = meals.Index().ViewData.Model as List<Meal>;
            Assert.Equal(5, list.Count);
            Assert.Equal("Prachtmaaltijd", list[0].Title);
            Assert.Equal("Prachtbeschrijving", list[0].Description);
            Assert.Equal("Z maaltijd", list[3].Title);
            Assert.NotEqual("Maaltijd van lang geleden", list[4].Title);
            Assert.Equal("Arno", list[4].Cook.Firstname);
            Assert.Equal("Broeders", list[4].Cook.Lastname);
            Assert.Equal(1, list[4].Cook.MealsAsCook.Count);
            Assert.Equal(0.45, list[3].Price);
        }
        [Fact]
        public void DetailPageWorks()
        {
            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            Mock<IUserRepository> UserMock = new Mock<IUserRepository>();

            ApplicationUser User = new ApplicationUser() { Firstname = "Arno", Lastname = "Broeders" };
            Meal Meal5 = new Meal()
            {
                ID = 5,
                Cook = User,
                Date = DateTime.Now.AddDays(2)
            };
            User.MealsAsCook.Add(Meal5);
            mock.Setup(m => m.Meals).Returns(new List<Meal>()
            {
                new Meal() { ID=0, Title = "Prachtmaaltijd", Description = "Prachtbeschrijving", Price = 0.25, Date = DateTime.Now.AddDays(4)},
                new Meal() { ID=1, Title = "Supermaaltijd", Description = "Superbeschrijving", Price = 0.85, Date = DateTime.Now.AddDays(2)},
                new Meal() { ID=2, Title = "Machtige maaltijd", Description = "Machtige beschrijving", Price = 0.55, Date = DateTime.Now.AddDays(7)},
                new Meal() { ID=3, Title = "Z maaltijd", Description = "Z beschrijving", Price = 0.45, Date = DateTime.Now.AddDays(5)},
                new Meal() { ID=4, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(-1)},
                Meal5
            });

            MealController meals = new MealController(mock.Object, UserMock.Object);
            Meal Meal = meals.Detail(0).ViewData.Model as Meal;
            Assert.Equal("Prachtmaaltijd", Meal.Title);
            Assert.Equal("Prachtbeschrijving", Meal.Description);
            Assert.Equal(0.25, Meal.Price);
        }
        [Fact]

    }
}
