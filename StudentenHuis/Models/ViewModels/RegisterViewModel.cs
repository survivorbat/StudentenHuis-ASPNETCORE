using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentenHuis.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Gebruikersnaam")]
        [StringLength(100, ErrorMessage = "{0} moet minstens {2} en hoogstens {1} karakters lang zijn.", MinimumLength = 1)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Voornaam")]
        [StringLength(100, ErrorMessage = "{0} moet minstens {2} en hoogstens {1} karakters lang zijn.", MinimumLength = 1)]
        public string Firstname { get; set; }

        [Display(Name = "Middlename")]
        public string Middlename { get; set; }

        [Required]
        [Display(Name = "Achternaam")]
        [StringLength(100, ErrorMessage = "{0} moet minstens {2} en hoogstens {1} karakters lang zijn.", MinimumLength = 6)]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefoonnummer")]
        public string Phonenumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} moet minstens {2} en hoogstens {1} karakters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord bevestigen")]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen")]
        public string ConfirmPassword { get; set; }
    }
}
