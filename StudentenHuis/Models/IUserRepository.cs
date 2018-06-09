using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> Users { get; }
    }
}
