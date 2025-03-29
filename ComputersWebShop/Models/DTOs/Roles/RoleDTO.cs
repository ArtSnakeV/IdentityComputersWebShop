using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ComputersWebShop.Models.DTOs.Roles
{
    public class RoleDTO
    {
        public string Id { get; set; } = default!;
        [Display(Name = "Role title")]
        public string Name { get; set; } = default!;

    }
}
