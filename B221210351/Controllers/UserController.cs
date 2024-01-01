using B221210351.EFContext;
using B221210351.Models;
using B221210351.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B221210351.Controllers
{
    public class UserController : Controller
    {
        private readonly HastaneDbContext context;
        private readonly UserManager<AppUser> userManager;


        public UserController(HastaneDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            int tempUserId = Convert.ToInt32(userManager.GetUserId(HttpContext.User));//Kullanıcının UserId bilgisini alma
            AppUser user = context.Users.Find(tempUserId);

            UpdateUserVM userVM = new UpdateUserVM
            {
                PatientName = user.PatientName,
                PatientSurname = user.PatientSurname,
                Email = user.Email,
                PatientGender = user.PatientGender,
                PatientBirthDay = user.PatientBirthDay,
                PhoneNumber = user.PhoneNumber
            };
            return View(userVM);
        }

        [HttpPost]
        public IActionResult Index(UpdateUserVM userVM)
        {
            int tempUserId = Convert.ToInt32(userManager.GetUserId(HttpContext.User));//Kullanıcının UserId bilgisini alma
            AppUser user = context.Users.Find(tempUserId);

            user.PatientName = userVM.PatientName;
            user.PatientSurname = userVM.PatientSurname;
            user.Email = userVM.Email;
            user.PatientGender = userVM.PatientGender;
            user.PatientBirthDay = userVM.PatientBirthDay;
            user.PhoneNumber = userVM.PhoneNumber;

            TempData["userUpdate"] = "Kullanıcı bilgileriniz başarıyla güncellenmiştir.";
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
