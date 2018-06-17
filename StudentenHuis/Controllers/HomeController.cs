using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentenHuis.Models;

namespace StudentenHuis.Controllers
{
    public class HomeController : Controller
    {
        // Render de index pagina met default tekst
        public ViewResult index()
        {
            return View();
        }
    }
}
