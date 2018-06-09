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
        [StringLength(100, ErrorMessage = "Een titel moet mnimaal 5 tekens bevatten", MinimumLength = 5), Required(ErrorMessage = "Een titel is vereist")]
        public string Title { get; set; }

        [MaxLength(1000)]
        [StringLength(1000, ErrorMessage = "Een beschrijving mag maximaal 1000 tekens bevatten")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Datum en tijd zijn vereist")]
        public DateTime Date { get; set; }

        public virtual ApplicationUser Cook { get; set; }

        [Range(1,50, ErrorMessage = "Dit getal moet tussen de 1 en 50 zijn"), Required(ErrorMessage = "Een maximaal aantal gasten is vereist")]
        public int MaxAmountOfGuests { get; set; }

        [Range(0,50, ErrorMessage = "De prijs moet tussen de 0 en 50 zijn"), Required(ErrorMessage = "Een prijs is vereist")]
        public double Price { get; set; }

        public virtual ICollection<MealStudent> Eaters { get; set; }
    }
}
