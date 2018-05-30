using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models.ViewModels
{

    public class SideBarViewModel
    {
        public UserManager<ApplicationUser> UM;
        public Meal Today { get; set; }
        public ApplicationUser User { get; set; }

        public SideBarViewModel(IMealRepository meal, ApplicationUser User)
        {
            if(User != null)
            {
                this.User = User;
            }
            try
            {
                Today = meal.Meals.Where(e => e.Date.Date.CompareTo(DateTime.Today.Date) == 0).First();
            }
            catch (Exception e)
            {
                
            }
            
        }
    }
}
