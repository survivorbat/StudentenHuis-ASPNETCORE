using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public class Meal
    {
        public int ID { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Datum { get; set; }
        public Student kok { get; set; }
        public int MaximaalAantalGasten { get; set; }
        public double Prijs { get; set; }
        public IEnumerable<Student> MeeEters { get; set; }
    }
}
