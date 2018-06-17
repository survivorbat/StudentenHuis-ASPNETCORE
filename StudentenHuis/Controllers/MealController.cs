using System;
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
        // Meal repository om de maaltijden op te halen
        private IMealRepository MealRepository;

        // User repository voor validaties
        private IUserRepository UserRepository;

        // Constructor met twee dependencies 
        public MealController(IMealRepository MealRepository, IUserRepository UserRepository)
        {
            this.MealRepository = MealRepository;
            this.UserRepository = UserRepository;
        }

        // Index pagina met een lijst aan maaltijden in de komende twee weken en vandaag
        public ViewResult Index()
        {
            return View(MealRepository.Meals.Where(e => e.Date.Date.CompareTo(DateTime.Now.Date) >= 0).Where(e => e.Date.Date.CompareTo(DateTime.Now.Date.AddDays(14)) < 0).ToList());
        }

        
        // Detail pagina voor gedetailleerde informatie over een maaltijd
        public ViewResult Detail(int ID)
        {
            return View(MealRepository.Meals.Where(e => e.ID == ID).FirstOrDefault());
        }

        // Nieuwe maaltijden mogen alleen aangemaakt worden door een ingelogde student
        [Authorize]

        // Nieuwe maaltijd
        public ViewResult NewMeal()
        {
            return View(new Meal());
        }

        // Een maaltijd aanpassen, de informatie over de maaltijd wordt meegegeven
        [Authorize]
        public ViewResult EditMeal(int ID)
        {
            return View(MealRepository.Meals.Where(e => e.ID == ID).FirstOrDefault());
        }

        // De POST request om de meal aan te passen
        [Authorize]
        [HttpPost]
        public IActionResult EditMeal(Meal Meal)
        {
            // In het geval dat het aantal eters niet 0 is dan geven we een error (zou niet mogelijk moeten zijn)
            if (Meal.Eaters.Count != 0) return Redirect("/Error");
            // Kijk of het succesvol is gegaan en redirect dan terug naar de maaltijd pagina

            // Bekijk of gebruiker wel de kok is
            if (User != null && !Meal.Cook.Id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier))) return View("Error");

            if (MealRepository.UpdateMeal(Meal))
            {
                return Redirect("/Meal");
            }
            else
            {
                // Anders returnen we de view met eventuele validatie
                return View(Meal);
            }
        }

        [Authorize]
        [HttpPost]
        // Post request met nieuwe maaltijd
        public IActionResult NewMeal(Meal Meal)
        {
            // Zet het user id om in een applicationuser
            Meal.Cook = UserRepository.Users.Where(e => e.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            
            // Indien de maaltijd goed toegevoegd is dan gaan we terug naar het maaltijden overzicht
            if (MealRepository.CreateMeal(Meal))
            {
                return Redirect("/Meal");
            } else
            {
                // Indien dit fout ging returnen we de maaltijd en geven we aan dat er al een maaltijd gepland is
                ModelState.AddModelError("Date", "A meal is already planned on this day");
                return View(Meal);
            }
        }

        // Sluit je aan bij een maaltijd
        [Authorize]
        [HttpPost]
        public IActionResult JoinMeal(MealButtonViewModel MealButtonViewModel)
        {
            // Krijg de maaltijd vanuit het ID
            Meal Meal = MealRepository.Meals.Where(e => e.ID == MealButtonViewModel.MealID).FirstOrDefault();

            // Zit hij niet al vol?
            if (Meal?.Eaters?.Count >= Meal.MaxAmountOfGuests) return View("Error");

            // Voeg gebruiker toe
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
        // Verlaat een maaltijd
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

        // Verwijder een maaltijd
        [Authorize]
        [HttpPost]
        public IActionResult DeleteMeal(MealButtonViewModel MealButtonViewModel)
        {
            // Krijg het maaltijd object
            Meal Meal = MealRepository.Meals.Where(e => e.ID == MealButtonViewModel.MealID).FirstOrDefault();

            // Bekijk of maaltijd leeg is
            if (Meal.Eaters.Count != 0) return View("Error");

            // Bekijk of gebruiker wel de kok is
            if (User != null && !Meal.Cook.Id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier))) return View("Error");

            // Verwijder maaltijd
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