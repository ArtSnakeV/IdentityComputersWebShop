using System.ComponentModel.DataAnnotations;

namespace ComputersWebShop.Models.DTOs.Users
{
    public class ShopUserDTO
    {
        public string Id { get; set; } = default!;

        [Display(Name = "Login")]
        public string UserName { get; set; } = default!;

        public string Email { get; set; } = default!;
        [Display(Name = "Date of birth")]
        public DateOnly DateOfBirth { get; set; }
        
    }
}
