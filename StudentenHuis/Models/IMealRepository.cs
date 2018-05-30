using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public interface IMealRepository
    {
        IEnumerable<Meal> Meals { get; }
        bool JoinMeal(Meal Meal, string User);
        bool LeaveMeal(Meal meal, string User);

        bool CreateMeal(Meal meal);
        bool DeleteMeal(Meal meal);
    }
}
