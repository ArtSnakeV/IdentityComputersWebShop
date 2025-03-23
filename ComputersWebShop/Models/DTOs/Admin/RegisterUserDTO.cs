using System.ComponentModel.DataAnnotations;

namespace ComputersWebShop.Models.DTOs.Admin
{
    public class RegisterUserDTO
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Login")]
        public string Username { get; set; } = default!;
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required]
        [Display(Name = "Password confirmation")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = default!;

        // To remain in system or exit
        [Display(Name = "Remain in system")]
        public bool IsPersistent { get; set; }
    }
}
