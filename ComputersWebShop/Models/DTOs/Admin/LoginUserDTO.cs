using System.ComponentModel.DataAnnotations;

namespace ComputersWebShop.Models.DTOs.Admin
{
    public class LoginUserDTO
    {
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; } = default!;

        public int Id { get; set; }

        [Required]
        [Display(Name = "Login")]
        public string Username { get; set; } = default!;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        
        [Display(Name = "Remain in the system")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
