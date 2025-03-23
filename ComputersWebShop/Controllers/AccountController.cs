using ComputersWebShop.Data;
using ComputersWebShop.Models.DTOs.Admin;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputersWebShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ShopUser> userManager;
        private readonly SignInManager<ShopUser> signInManager;

        public AccountController(UserManager<ShopUser> userManager,
            SignInManager<ShopUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDTO dTO)
        {
            if (!ModelState.IsValid)
                return View(dTO);
            ShopUser shopUser = new ShopUser
            {
                UserName = dTO.Username,
                Email = dTO.Email,
                DateOfBirth = dTO.DateOfBirth,
            };
            var result = await userManager.CreateAsync(shopUser, dTO.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(shopUser, false); // false meanse do not remain in system
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(dTO);
        }


        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDTO dTO)
        {
            if (!ModelState.IsValid)
                return View(dTO);
            ShopUser? shopUser = await userManager.FindByNameAsync(dTO.Username);
            if (shopUser != null)
            {
                var result = await signInManager.PasswordSignInAsync(shopUser, dTO.Password,
                    dTO.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("Index");
                else
                    ModelState.AddModelError(string.Empty, "User/Password is wrong");
            }
            else
                ModelState.AddModelError(string.Empty, "User not found");
            return View(dTO);
        }

        // To see all users
        public async Task<IActionResult> Index()
        {
            IEnumerable<ShopUser> users = await userManager.Users.ToListAsync();
            return View(users);
        }

        //public IActionResult Login(string returnUrl)
        //{
        //    LoginUserDTO userDTO = new LoginUserDTO() { ReturnUrl = returnUrl };
        //    return View(userDTO);
        //}

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            return RedirectToAction("Index");
        }
    }
}

