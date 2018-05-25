using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    interface IMealRepository
    {
        IEnumerable<Meal> Meals { get; }
    }
}
