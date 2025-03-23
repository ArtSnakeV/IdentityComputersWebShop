using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ComputersWebShop.Data
{
    public class ShopUser : IdentityUser
    {
        //[Display(Name = "Date of birth: ")]
        public DateOnly DateOfBirth { get; set; }
    }
}
