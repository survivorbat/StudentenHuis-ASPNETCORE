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
            mock.Setup(m => m.Meals).Returns(new Meal[]
            {
                new Meal() { ID=0, Title = "Prachtmaaltijd", Description = "Prachtbeschrijving", Price = 0.25},
                new Meal() { ID=1, Title = "Supermaaltijd", Description = "Superbeschrijving", Price = 0.85},
                new Meal() { ID=2, Title = "Machtige maaltijd", Description = "Machtige beschrijving", Price = 0.55},
                new Meal() { ID=3, Title = "Z maaltijd", Description = "Z beschrijving", Price = 0.45}
            });

            MealController meals = new MealController(mock.Object);
            Meal[] list = meals.Index().ViewData.Model as Meal[];
            Assert.Equal(4, list.Length);
            Assert.Equal("Prachtmaaltijd", list[0].Title);
            Assert.Equal("Prachtbeschrijving", list[0].Description);
            Assert.Equal("Z maaltijd", list[3].Title);
            Assert.Equal(0.45, list[4].Price);
        }
    }
}
