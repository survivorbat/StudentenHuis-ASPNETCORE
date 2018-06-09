using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models.ViewModels
{
    public class MealButtonViewModel
    {
        public Meal Meal { get; set; }
        public string Affiliation { get; set; }
        public int MealID { get; set; }
    }
}
