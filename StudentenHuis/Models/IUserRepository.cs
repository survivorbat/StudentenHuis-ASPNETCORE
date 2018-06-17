using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    // Om gemakkelijk de gebruikers op te halen
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> Users { get; }
    }
}
