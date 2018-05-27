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
            Eaters = new List<Student>();
        }
        public int ID { get; set; }

        [StringLength(25, ErrorMessage = "Een titel moet mnimaal 5 tekens bevatten", MinimumLength = 5), Required(ErrorMessage = "Een titel is vereist")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Een beschrijving mag maximaal 500 tekens bevatten")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Datum en tijd zijn vereist")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Een maaltijd moet gekookt worden door een student")]
        public virtual Student Cook { get; set; }

        [Range(1,50, ErrorMessage = "Dit getal moet tussen de 1 en 50 zijn"), Required(ErrorMessage = "Een maximaal aantal gasten is vereist")]
        public int MaxAmountOfGuests { get; set; }

        [Range(0,50, ErrorMessage = "De prijs moet tussen de 0 en 50 zijn"), Required(ErrorMessage = "Een prijs is vereist")]
        public double Price { get; set; }

        public virtual ICollection<Student> Eaters { get; set; }
    }
}
