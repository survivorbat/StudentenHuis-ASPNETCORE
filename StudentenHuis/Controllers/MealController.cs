using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentenHuis.Models;

namespace StudentenHuis.Controllers
{
    public class MealController : Controller
    {
        private IMealRepository MealRepository;
        public MealController(IMealRepository mealRepository)
        {
            this.MealRepository = mealRepository;
        }
        public ViewResult Index()
        {
            return View(MealRepository.Meals.Where(e => e.Date.Date.CompareTo(DateTime.Now.Date) >= 0));
        }
        
        public ViewResult Detail(int ID)
        {
            return View(MealRepository.Meals.Where(e => e.ID == ID).First());
        }

        [Authorize]
        [HttpPost]
        public IActionResult JoinMeal(Meal Meal)
        {
            if (MealRepository.JoinMeal(Meal, User.FindFirstValue(ClaimTypes.NameIdentifier))) {
                return RedirectToActionPermanent("Index");
            }
            else
            {
                return View("Error");
            }
        }
    }
}