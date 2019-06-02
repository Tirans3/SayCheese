using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.ViewModels
{
    public class LoginViewModel
    {
       
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
     
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$",
             ErrorMessage = @"Password must be at least 4 characters, 
no more than 8 characters, and must include at least one upper case letter, 
one lower case letter, and one numeric digit")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "RememberMe?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
