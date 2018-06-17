using Microsoft.AspNetCore.Mvc;
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
        public void IndexReturnsOnlyNextTwoWeeks()
        {
            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            Mock<IUserRepository> UserMock = new Mock<IUserRepository>();

            mock.Setup(m => m.Meals).Returns(new List<Meal>()
            {
                new Meal() { ID=0, Title = "Prachtmaaltijd", Description = "Prachtbeschrijving", Price = 0.25, Date = DateTime.Now.AddDays(4)},
                new Meal() { ID=44, Title = "Supermaaltijd", Description = "Superbeschrijving", Price = 0.85, Date = DateTime.Now.AddDays(2)},
                new Meal() { ID=24, Title = "Supermaaltijd", Description = "Superbeschrijving", Price = 0.85, Date = DateTime.Now.AddDays(3)},
                new Meal() { ID=29, Title = "Supermaaltijd", Description = "Superbeschrijving", Price = 0.85, Date = DateTime.Now.AddDays(1)},
                new Meal() { ID=2, Title = "Machtige maaltijd", Description = "Machtige beschrijving", Price = 0.55, Date = DateTime.Now.AddDays(7)},
                new Meal() { ID=3, Title = "Z maaltijd", Description = "Z beschrijving", Price = 0.45, Date = DateTime.Now.AddDays(5)},
                new Meal() { ID=1, Title = "Maaltijd van lang geleden", Date = DateTime.Now},
                new Meal() { ID=4, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(6)},
                new Meal() { ID=5, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(7)},
                new Meal() { ID=6, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(8)},
                new Meal() { ID=7, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(9)},
                new Meal() { ID=8, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(10)},
                new Meal() { ID=9, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(11)},
                new Meal() { ID=10, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(12)},
                new Meal() { ID=11, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(13)},
                new Meal() { ID=12, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(14)},
                new Meal() { ID=13, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(15)},
                new Meal() { ID=14, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(16)},
                new Meal() { ID=15, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(17)},
                new Meal() { ID=16, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(18)},
                new Meal() { ID=17, Title = "Maaltijd van lang geleden", Date = DateTime.Now.AddDays(-1)}
            });

            MealController meals = new MealController(mock.Object, UserMock.Object);
            List<Meal> list = meals.Index().ViewData.Model as List<Meal>;
            Assert.Equal(15, list.Count);
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
        public void CantJoinWithManyEaters()
        {
            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            Mock<IUserRepository> UserMock = new Mock<IUserRepository>();

            ApplicationUser User = new ApplicationUser() { Firstname = "Arno", Lastname = "Broeders" };
            Meal Meal5 = new Meal()
            {
                ID = 5,
                Cook = User,
                Date = DateTime.Now.AddDays(2),
                MaxAmountOfGuests = 1,
                Price = 2.40,
                Title = "Superdeal",
                Description = "Superdeal"
            };
            User.MealsAsCook.Add(Meal5);
            mock.Setup(m => m.Meals).Returns(new List<Meal>()
            {
                Meal5
            });
            mock.Setup(m => m.JoinMeal(It.IsAny<int>(), It.IsAny<string>())).Returns((int meal, string user) =>
            {
                if(Meal5.Eaters.Count < Meal5.MaxAmountOfGuests)
                {
                    Meal5.Eaters.Add(new MealStudent());
                    return true;
                } 
                return false;
            });

            MealController Controller = new MealController(mock.Object, UserMock.Object);
            RedirectResult Result = Controller.JoinMeal(new StudentenHuis.Models.ViewModels.MealButtonViewModel()
            {
                MealID = 5,
            }) as RedirectResult;
            Assert.Equal("/Meal", Result?.Url ?? "");
            ViewResult ViewResult = Controller.JoinMeal(new StudentenHuis.Models.ViewModels.MealButtonViewModel()
            {
                MealID = 5,
            }) as ViewResult;
            Assert.Equal("Error", ViewResult?.ViewName ?? "");
            
        }
        [Fact]
        public void CantDeleteWithEaters()
        {
            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            Mock<IUserRepository> UserMock = new Mock<IUserRepository>();

            ApplicationUser User = new ApplicationUser() { Firstname = "Arno", Lastname = "Broeders" };
            Meal Meal5 = new Meal()
            {
                ID = 5,
                Cook = User,
                Date = DateTime.Now.AddDays(2),
                MaxAmountOfGuests = 1,
                Price = 2.40,
                Title = "Superdeal",
                Description = "Superdeal"
            };
            User.MealsAsCook.Add(Meal5);
            mock.Setup(m => m.Meals).Returns(new List<Meal>()
            {
                Meal5
            });
            mock.Setup(m => m.JoinMeal(It.IsAny<int>(), It.IsAny<string>())).Returns((int meal, string user) =>
            {
                if (Meal5.Eaters.Count < Meal5.MaxAmountOfGuests)
                {
                    Meal5.Eaters.Add(new MealStudent());
                    return true;
                }
                return false;
            });
            mock.Setup(m => m.DeleteMeal(It.IsAny<int>())).Returns((int meal) =>
            {
                if (Meal5.Eaters.Count == 0)
                {
                    return true;
                }
                return false;
            });

            MealController Controller = new MealController(mock.Object, UserMock.Object);
            RedirectResult DeletedMeal = Controller.DeleteMeal(new StudentenHuis.Models.ViewModels.MealButtonViewModel()
            {
                MealID = 5
            }) as RedirectResult;
            Assert.Equal("/Meal", DeletedMeal?.Url ?? "");
            Controller.JoinMeal(new StudentenHuis.Models.ViewModels.MealButtonViewModel()
            {
                MealID = 5,
            });
            ViewResult ViewResult = Controller.DeleteMeal(new StudentenHuis.Models.ViewModels.MealButtonViewModel()
            {
                MealID = 5,
            }) as ViewResult;
            Assert.Equal("Error", ViewResult?.ViewName ?? "");
        }
        [Fact]
        public void CantUpdateWithEaters()
        {
            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            Mock<IUserRepository> UserMock = new Mock<IUserRepository>();

            ApplicationUser User = new ApplicationUser() { Firstname = "Arno", Lastname = "Broeders" };
            Meal Meal5 = new Meal()
            {
                ID = 5,
                Cook = User,
                Date = DateTime.Now.AddDays(2),
                MaxAmountOfGuests = 1,
                Price = 2.40,
                Title = "Superdeal",
                Description = "Superdeal"
            };
            User.MealsAsCook.Add(Meal5);
            mock.Setup(m => m.Meals).Returns(new List<Meal>()
            {
                Meal5
            });
            mock.Setup(m => m.JoinMeal(It.IsAny<int>(), It.IsAny<string>())).Returns((int meal, string user) =>
            {
                if (Meal5.Eaters.Count < Meal5.MaxAmountOfGuests)
                {
                    Meal5.Eaters.Add(new MealStudent());
                    return true;
                }
                return false;
            });
            mock.Setup(m => m.UpdateMeal(It.IsAny<Meal>())).Returns((Meal meal) =>
            {
                if (Meal5.Eaters.Count == 0)
                {
                    return true;
                }
                return false;
            });

            MealController Controller = new MealController(mock.Object, UserMock.Object);
            RedirectResult EditedMeal = Controller.EditMeal(Meal5) as RedirectResult;
            Assert.Equal("/Meal", EditedMeal?.Url ?? "");
            Controller.JoinMeal(new StudentenHuis.Models.ViewModels.MealButtonViewModel()
            {
                MealID = 5,
            });
            ViewResult ViewResult = Controller.DeleteMeal(new StudentenHuis.Models.ViewModels.MealButtonViewModel()
            {
                MealID = 5,
            }) as ViewResult;
            Assert.Equal("Error", ViewResult?.ViewName ?? "");
        }
    }
}
