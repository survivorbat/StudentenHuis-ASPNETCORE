using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public class Meal
    {
        public Meal()
        {
            Eaters = new HashSet<MealStudent>();
        }
        public int ID { get; set; }

        [MaxLength(100)]
        [StringLength(100, ErrorMessage = "A title has to be at least 5 charactes long", MinimumLength = 5), Required(ErrorMessage = "A title is required")]
        public string Title { get; set; }

        [MaxLength(1000)]
        [StringLength(1000, ErrorMessage = "A description can not be longer than 1000 characters")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Date and time are required")]
        public DateTime Date { get; set; }

        public virtual ApplicationUser Cook { get; set; }

        [Range(1,50, ErrorMessage = "This number must be between {0} and {1}"), Required(ErrorMessage = "Een maximaal aantal gasten is vereist")]
        public int MaxAmountOfGuests { get; set; }

        [Range(0,50, ErrorMessage = "This number must be between {0} and {1}"), Required(ErrorMessage = "Een prijs is vereist")]
        public double Price { get; set; }

        public virtual ICollection<MealStudent> Eaters { get; set; }
    }
}
