using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Configurator.ViewModels
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string LoginEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }


        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        public bool IsAdmin { get; set; }

        public UserModel GetUser()
        {
            return new UserModel
            {
                Id = Id,
                LoginEmail = LoginEmail,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName,
                Company = Company,
                Telephone = Telephone,
                Address = Address,
                IsAdmin = IsAdmin
            };
        }
    }
}