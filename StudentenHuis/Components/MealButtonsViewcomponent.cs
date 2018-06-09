using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentenHuis.Models;
using StudentenHuis.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentenHuis.Components
{
    public class MealButtonsViewcomponent : ViewComponent
    {
        public IViewComponentResult Invoke(Meal Meal)
        {
            var User = this.HttpContext.User;
            string UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);    
            
            if (UserID == null) return View("Default", new MealButtonViewModel() { Meal = Meal, Affiliation = "NotLoggedIn" });
            if (Meal.Cook.Id == UserID && Meal.Eaters.Count == 0) return View("Default", new MealButtonViewModel() { Meal = Meal, Affiliation = "IsCook" });
            if (Meal.Cook.Id == UserID) return View("Default", new MealButtonViewModel() { Meal = Meal, Affiliation = "IsCookAndNotEmpty" });
            if (Meal.Eaters.Select(e => e.ApplicationUserId).Contains(UserID)) return View("Default", new MealButtonViewModel() { Meal = Meal, Affiliation = "Eater" });
            if (Meal.MaxAmountOfGuests <= Meal.Eaters.Count()) return View("Default", new MealButtonViewModel() { Meal = Meal, Affiliation = "Full" });
            return View("Default",new MealButtonViewModel() { Meal = Meal, Affiliation = "Default", MealID = Meal.ID });
        }
    }
}
