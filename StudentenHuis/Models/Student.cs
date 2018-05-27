using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public class Student
    {
        public Student()
        {
            MealsAsEater = new List<Meal>();
            MealsAsCook = new List<Meal>();
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "Een voornaam is vereist"), StringLength(50, ErrorMessage = "Een voornaam moet tussen de 0 en 50 tekens zijn", MinimumLength = 0)]
        public string Firstname { get; set; }
        public string Middlename { get; set; }

        [Required(ErrorMessage = "Een achternaam is vereist"), StringLength(50, ErrorMessage = "Een achternaam moet tussen de 0 en 50 tekens zijn", MinimumLength = 0)]
        public string Lastname { get; set; }

        public virtual ICollection<Meal> MealsAsEater { get; set; }
        public virtual ICollection<Meal> MealsAsCook { get; set; }

        [Required(ErrorMessage = "Een e-mail adres is vereist"), EmailAddress(ErrorMessage = "Een valide e-mail adres is vereist")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Een telefoonnummer is vereist"), Phone(ErrorMessage = "Een valide telefoonnummer is vereist")]
        public string Telephonenumber { get; set; }
    }
}
