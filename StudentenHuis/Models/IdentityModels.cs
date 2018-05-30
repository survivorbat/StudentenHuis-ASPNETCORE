using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudentenHuis.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            MealsAsEater = new HashSet<MealStudent>();
            MealsAsCook = new HashSet<MealStudent>();
        }
        public virtual string Firstname { get; set; }
        public virtual string Middlename { get; set; }
        public virtual string Lastname { get; set; }
        public virtual ICollection<MealStudent> MealsAsEater { get; set; }
        public virtual ICollection<MealStudent> MealsAsCook { get; set; }

        public string Fullname()
        {
            return Firstname+" "+Middlename+" "+Lastname;
        }
    }
}
