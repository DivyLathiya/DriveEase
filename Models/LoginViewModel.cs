using System.ComponentModel.DataAnnotations;

namespace CarRentalMvc.Models
{
    // This model is used ONLY for the login page
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } // We won't check this, but it's standard

        [Required]
        public string Role { get; set; } // "User" or "Admin"
    }
}
