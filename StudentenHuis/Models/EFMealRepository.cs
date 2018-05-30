using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public class EFMealRepository : IMealRepository
    {
        private ApplicationDbContext DB;
        public EFMealRepository(ApplicationDbContext db)
        {
            this.DB = db;
        }

        IEnumerable<Meal> IMealRepository.Meals => DB.Meals.Include(e => e.Cook).Include(e => e.Eaters).OrderByDescending(e => e.Date).ToList();

        public bool CreateMeal(Meal meal)
        {
            DB.Add(meal);
            return DB.SaveChanges() == 1;
        }

        public bool DeleteMeal(Meal meal)
        {
            DB.Remove(meal);
            return DB.SaveChanges() == 1;
        }

        public bool JoinMeal(Meal Meal, string User)
        {
            DB.MealStudents.Add(new MealStudent()
            {
                ApplicationUserId = User,
                MealId = Meal.ID,
                Meal = Meal
            });
            return DB.SaveChanges() > 0;
        }

        public bool LeaveMeal(Meal Meal, string User)
        {
            DB.MealStudents.Remove(new MealStudent()
            {
                ApplicationUserId = User,
                MealId = Meal.ID,
                Meal = Meal
            });
            return DB.SaveChanges() > 0;
        }
    }
}
