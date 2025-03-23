using AutoMapper;
using ComputersWebShop.Data;
using ComputersWebShop.Models.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputersWebShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ShopUser> userManager;
        private readonly IMapper mapper;

        public UsersController(UserManager<ShopUser> userManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ShopUser> users = await userManager.Users.ToListAsync();
            IEnumerable<ShopUserDTO> userDTOs = mapper.Map<IEnumerable<ShopUserDTO>>(users);
            return View(userDTOs);
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
                return NotFound();
            ShopUser? shopUser = await userManager.FindByIdAsync(id);
            if (shopUser == null)
                return NotFound("User not found!");
            ShopUserDTO userDTO = mapper.Map<ShopUserDTO>(shopUser);
            return View(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ShopUserDTO userDTO)
        {
            if (!ModelState.IsValid)
                return View(userDTO);
            ShopUser? user = await userManager.FindByIdAsync(userDTO.Id);
            if (user != null)
            {
                user.DateOfBirth = userDTO.DateOfBirth;
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            else
                ModelState.AddModelError(string.Empty, "User not found!");
            return View(userDTO);
        }
    }
}
