using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Configurator.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email address cannot be empty.")]
        [Display(Name = "Email")]
        [RegularExpression(@"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?", ErrorMessage = "Invalid Email.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "At least four charactors.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)]       
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string RepeatPassword { get; set; }
    }
}