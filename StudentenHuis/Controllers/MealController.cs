using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentenHuis.Models;

namespace StudentenHuis.Controllers
{
    public class MealController : Controller
    {
        private IMealRepository mealRepository;
        public MealController(IMealRepository mealRepository)
        {
            this.mealRepository = mealRepository;
        }
        public ViewResult Index()
        {
            return View(mealRepository.Meals);
        }
    }
}