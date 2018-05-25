using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public class FakeMealRepository : IMealRepository
    {
        public IEnumerable<Meal> Meals => new List<Meal> {
            new Meal() {ID = 2}
        };
    }
}
