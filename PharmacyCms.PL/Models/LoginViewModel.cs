using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.PL.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [MinLength(5, ErrorMessage = "Minimum length for password is 5")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ValidateNever]
        public bool RememberMe { get; set; } = false;

    }
}
