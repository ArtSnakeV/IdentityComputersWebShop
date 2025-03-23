using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ComputersLibrary;
using ComputersWebShop.Models.DTOs.Admin;
using ComputersWebShop.Models.DTOs.Users;

namespace ComputersWebShop.Data
{
    public class ShopContext : IdentityDbContext<ShopUser>
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        { }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> Images { get; set; }


        //public DbSet<ComputersWebShop.Models.DTOs.Admin.LoginUserDTO> LoginUserDTO { get; set; } = default!;
        //public DbSet<ComputersWebShop.Models.DTOs.Users.ShopUserDTO> ShopUserDTO { get; set; } = default!;
        //public DbSet<ComputersWebShop.Models.DTOs.Admin.RegisterUserDTO> RegisterUserDTO { get; set; } = default!;
        
        //public DbSet<ComputerWebShop.Models.DTOs.Roles.RoleDTO> RoleDTO { get; set; } = default!;
        
    }
}
