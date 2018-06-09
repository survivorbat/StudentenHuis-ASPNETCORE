using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public class FakeMealRepository //: IMealRepository
    {
        public IEnumerable<Meal> Meals => new List<Meal> {
            new Meal()
            {
                ID = 0,
                Title = "Spaghetti",
                Description = "Erg lekker spaghetti bord",
                Price = 2.35,
                Date = new DateTime(2018,1,1),
                MaxAmountOfGuests = 10
            }
        };

        public bool CreateMeal(Meal meal)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMeal(Meal meal)
        {
            throw new NotImplementedException();
        }

        public bool JoinMeal(Meal Meal, string User)
        {
            throw new NotImplementedException();
        }

        public bool LeaveMeal(Meal meal, string User)
        {
            throw new NotImplementedException();
        }
    }
}
