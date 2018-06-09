using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public interface IMealRepository
    {
        IEnumerable<Meal> Meals { get; }
        bool JoinMeal(int Meal, string User);
        bool LeaveMeal(int Meal, string User);

        bool CreateMeal(Meal Meal);
        bool UpdateMeal(Meal Meal);
        bool DeleteMeal(int MealID);
    }
}
