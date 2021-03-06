﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentenHuis.Models;
using StudentenHuis.Models.ViewModels;

namespace StudentenHuis.Controllers
{
    public class MealController : Controller
    {
        private IMealRepository MealRepository;
        private IUserRepository UserRepository;
        public MealController(IMealRepository MealRepository, IUserRepository UserRepository)
        {
            this.MealRepository = MealRepository;
            this.UserRepository = UserRepository;
        }
        public ViewResult Index()
        {
            return View(MealRepository.Meals.Where(e => e.Date.Date.CompareTo(DateTime.Now.Date) >= 0).Where(e => e.Date.Date.CompareTo(DateTime.Now.Date.AddDays(14)) < 0).ToList());
        }
        
        [Authorize]
        public ViewResult Detail(int ID)
        {
            return View(MealRepository.Meals.Where(e => e.ID == ID).FirstOrDefault());
        }

        [Authorize]
        public ViewResult NewMeal()
        {
            return View(new Meal());
        }

        [Authorize]
        public ViewResult EditMeal(int ID)
        {
            return View(MealRepository.Meals.Where(e => e.ID == ID).FirstOrDefault());
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditMeal(Meal Meal)
        {
            if (Meal.Eaters.Count != 0) return Redirect("/Error");
            if (MealRepository.UpdateMeal(Meal))
            {
                return Redirect("/Meal");
            }
            else
            {
                return View(Meal);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult NewMeal(Meal Meal)
        {
            Meal.Cook = UserRepository.Users.Where(e => e.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            if (MealRepository.CreateMeal(Meal))
            {
                return Redirect("/Meal");
            } else
            {
                ModelState.AddModelError("Date", "A meal is already planned on this day");
                return View(Meal);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult JoinMeal(MealButtonViewModel MealButtonViewModel)
        {
            Meal Meal = MealRepository.Meals.Where(e => e.ID == MealButtonViewModel.MealID).FirstOrDefault();
            if (Meal?.Eaters?.Count >= Meal.MaxAmountOfGuests) return View("Error");
            if (MealRepository.JoinMeal(MealButtonViewModel.MealID, User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "")) {
                return Redirect("/Meal");
            }
            else
            {
                return View("Error");
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult LeaveMeal(MealButtonViewModel MealButtonViewModel)
        {
            if (MealRepository.LeaveMeal(MealButtonViewModel.MealID, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Redirect("/Meal");
            }
            else
            {
                return View("Error");
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult DeleteMeal(MealButtonViewModel MealButtonViewModel)
        {
            Meal Meal = MealRepository.Meals.Where(e => e.ID == MealButtonViewModel.MealID).FirstOrDefault();
            if (Meal.Eaters.Count != 0) return View("Error");
            if (User != null && !Meal.Cook.Id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier))) return View("Error");
            if (MealRepository.DeleteMeal(MealButtonViewModel.MealID))
            {
                return Redirect("/Meal");
            }
            else
            {
                return View("Error");
            }
        }
    }
}