using Microsoft.AspNetCore.Mvc;
using StudentenHuis.Models;
using StudentenHuis.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Components
{
    public class SidebarViewComponent : ViewComponent
    {
        private IMealRepository Meal;
        public SidebarViewComponent(IMealRepository repo)
        {
            Meal = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(new SideBarViewModel(Meal));
        }
    }
}
