using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string TussenVoegsel { get; set; }
        public string Achternaam { get; set; }
        public IEnumerable<Meal> MaaltijdenAlsEter { get; set; }
        public IEnumerable<Meal> MaaltijdenAlsKok { get; set; }
        public string Emailadres { get; set; }
        public string Telefoonnummer { get; set; }
    }
}
