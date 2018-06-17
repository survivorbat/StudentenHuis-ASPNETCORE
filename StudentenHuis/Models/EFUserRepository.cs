using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudentenHuis.Models
{
    // Om gemakkelijk(er) de gebruikers op te halen uit de database, daarnaast vullen we ook maaltijden
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext DB;
        public EFUserRepository (ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        IEnumerable<ApplicationUser> IUserRepository.Users => DB.Users.Include("MealsAsCook").Include("MealsAsEater.Meal").ToList();
    }
}
