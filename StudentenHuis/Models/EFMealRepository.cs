using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public class EFMealRepository : IMealRepository
    {
        private ApplicationDbContext db;
        public EFMealRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        IEnumerable<Meal> IMealRepository.Meals => db.Meals.Include(e => e.Cook).OrderByDescending(e => e.Date).ToList();
    }
}
