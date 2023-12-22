using B221210351.Areas.YonetimPaneli.Models.ViewModels;
using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Mvc;

namespace B221210351.Areas.YonetimPaneli.Controllers
{
    [Area("yonetimPaneli")]
    public class HomeController : Controller
    {
        HastaneContext context = new HastaneContext();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (context.Users.Any(u => u.UserName == user.UserName))
            {
                User userControl = context.Users.FirstOrDefault(u => u.UserName == user.UserName);

                if (userControl.Password == user.Password && userControl.isAdmin)
                    return RedirectToAction("management");
            }
            TempData["hataMesaji"] = "Lütfen Bilgileri Doğru Giriniz";
            return View();
        }

        public IActionResult Management()
        {
            List<User> users = context.Users.ToList();
            List<Doctor> doctors = context.Doctors.ToList();
            List<Policlinic> policlinics = context.Policlinics.ToList();
            List<Department> departments = context.Departments.ToList();
            List<Appointment> appointments = context.Appointments.ToList();

            AppDatasForAdminVM appData = new()
            {
                Users = users,
                Doctors = doctors,
                Departments = departments
            };


            return View(appData);
        }
    }
}
