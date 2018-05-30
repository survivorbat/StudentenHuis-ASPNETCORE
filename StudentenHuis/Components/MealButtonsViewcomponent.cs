using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentenHuis.Models;
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
            
            if (UserID == null) return View("Default","NotLoggedIn");
            if (Meal.Cook.Id == UserID) return View("Default","IsCook");
            if (Meal.Eaters.Select(e => e.ApplicationUserId).Contains(UserID)) return View("Default","Eater");
            return View("Default","Default");
        }
    }
}
