using B221210351.EFContext;
using B221210351.Models;
using B221210351.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B221210351.Controllers
{
    public class HomeController : Controller
    {
        private readonly HastaneDbContext context;
        private readonly UserManager<AppUser> userManager;

        public HomeController(HastaneDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserVM loginUserVM)
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserVM appUserViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    PatientName = appUserViewModel.PatientName,
                    PatientSurname = appUserViewModel.PatientSurname,
                    UserName = appUserViewModel.UserName,
                    Email = appUserViewModel.Email,
                    PatientBirthDay = DateTime.Now,
                    Address = await context.Addresses.FindAsync(1)
                };
                IdentityResult result = await userManager.CreateAsync(appUser, appUserViewModel.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            }
            return View();
        }
    }
}
