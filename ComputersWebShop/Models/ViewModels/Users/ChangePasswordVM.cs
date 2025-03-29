using System.ComponentModel.DataAnnotations;

namespace ComputersWebShop.Models.ViewModels.Users
{
    public class ChangePasswordVM
    {
        public string Id { get; set; } = default!;

        public string? Email { get; set; } = default!;
        [Display(Name = "Please enter current password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = default!;
        [Display(Name = "Please enter new password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = default!;
        [Display(Name = "Please confirm new password")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; } = default!;
    }
}
