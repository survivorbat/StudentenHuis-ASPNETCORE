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

        IEnumerable<Meal> IMealRepository.Meals => DB.Meals.Include("Cook").Include("Eaters.ApplicationUser").OrderBy(e => e.Date).ToList();

        public bool CreateMeal(Meal Meal)
        {
            if(DB.Meals.Where(e => e.Date.Date.Equals(Meal.Date.Date)).Count() < 1)
            {
                DB.Meals.Add(Meal);
                return DB.SaveChanges() == 1;
            }
            else
            {
                return false;
            }
           
        }

        public bool UpdateMeal(Meal Meal)
        {
            Meal ChangingMeal = DB.Meals.Where(e => e.ID == Meal.ID).FirstOrDefault();
            if (ChangingMeal?.Eaters?.Count() != 0) return false;

            ChangingMeal.Title = Meal.Title;
            ChangingMeal.Description = Meal.Description;
            ChangingMeal.MaxAmountOfGuests = Meal.MaxAmountOfGuests;
            ChangingMeal.Price = Meal.Price;

            return DB.SaveChanges() > 0;
        }

        public bool DeleteMeal(int Meal)
        {
            Meal Selected = DB.Meals.Where(e => e.ID == Meal).FirstOrDefault();
            if (Selected.Eaters.Count() != 0) return false;
            if(Selected != null)
            {
                DB.Remove(Selected);
                return DB.SaveChanges() > 0;
            }
            return true;
        }

        public bool JoinMeal(int Meal, string User)
        {
            Meal Current = DB.Meals.Where(e => e.ID == Meal).FirstOrDefault();
            if (Current.Eaters.Count() >= Current.MaxAmountOfGuests) return false;
            DB.MealStudents.Add(new MealStudent()
            {
                ApplicationUserId = User,
                MealId = Meal
            });
            return DB.SaveChanges() > 0;
        }

        public bool LeaveMeal(int Meal, string User)
        {
            MealStudent MealStudent =  DB.MealStudents.Where(e => e.ApplicationUserId == User).Where(e => e.MealId == Meal).FirstOrDefault();
            if (MealStudent != null)
            {
                DB.MealStudents.Remove(MealStudent);
                return DB.SaveChanges() > 0;
            }
            return false;
        }
    }
}
