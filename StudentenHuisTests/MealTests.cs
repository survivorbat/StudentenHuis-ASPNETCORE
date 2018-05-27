using StudentenHuis.Models;
using System;
using Xunit;

namespace StudentenHuisTests
{
    public class MealTests
    {
        [Fact]
        public void SavesMealsProperly()
        {
            Meal TestMeal = new Meal()
            {
                ID = 0,
                Title = "Spaghetti",
                Description = "Erg lekker spaghetti bord",
                Price = 2.35,
                Cook = new Student(),
                Date = new DateTime(2018,1,1),
                MaxAmountOfGuests = 10
            };
            Assert.Equal(0, TestMeal.ID);
            Assert.Equal(10, TestMeal.MaxAmountOfGuests);
            Assert.Equal("Spaghetti", TestMeal.Title);
            Assert.Equal("Erg lekker spaghetti bord", TestMeal.Description);
            Assert.Equal(2.35, TestMeal.Price);
            Assert.Equal(new DateTime(2018, 1, 1), TestMeal.Date);
        }
    }
}
