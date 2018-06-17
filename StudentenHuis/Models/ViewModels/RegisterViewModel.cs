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
        [Display(Name = "Username")]
        [StringLength(100, ErrorMessage = "{0} has to be at least {2} and max {1} characters long", MinimumLength = 1)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        [StringLength(100, ErrorMessage = "{0} has to be at least {2} and max {1} characters long", MinimumLength = 1)]
        public string Firstname { get; set; }

        [Display(Name = "Middlename")]
        public string Middlename { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        [StringLength(100, ErrorMessage = "{0} has to be at least {2} and max {1} characters long", MinimumLength = 6)]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [RegularExpression("(06-[0-9]{8})", ErrorMessage = "A valid telephonenumber starts with 06- and contains 8 numbers")]
        [Display(Name = "Telephonenumber")]
        public string Phonenumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} has to be at least {2} and max {1} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password confirm")]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen")]
        public string ConfirmPassword { get; set; }
    }
}
