using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudentenHuis.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            MealsAsEater = new HashSet<MealStudent>();
            MealsAsCook = new HashSet<Meal>();
        }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        [RegularExpression("/^(((\\+31|0|0031)6){1}[1-9]{1}[0-9]{7})$/i", ErrorMessage = "Een telefoonnummer moet maximaal 9 tekens zijn en moet een - hebben.")]
        public string PhoneNumber { get; set; }
        public virtual ICollection<MealStudent> MealsAsEater { get; set; }
        public virtual ICollection<Meal> MealsAsCook { get; set; }

        public string Fullname()
        {
            return Firstname+" "+Middlename+" "+Lastname;
        }
    }
}
