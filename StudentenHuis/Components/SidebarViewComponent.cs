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
    public class SidebarViewComponent : ViewComponent
    {
        private IMealRepository Meal;
        private UserManager<ApplicationUser> UserManager;
        public SidebarViewComponent(IMealRepository repo, UserManager<ApplicationUser> UserManager)
        {
            Meal = repo;
            this.UserManager = UserManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var User = HttpContext.User;
            string UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser ApplicationUser = null;
            if (UserID != null) ApplicationUser = await UserManager.FindByIdAsync(UserID);
            return View(new SideBarViewModel(Meal, ApplicationUser));
        }
    }
}
