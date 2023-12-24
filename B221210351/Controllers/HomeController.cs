using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B221210351.Controllers
{
    public class HomeController : Controller
    {
        HastaneContext context = new HastaneContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AppUser patient)
        {
            if(context.Patients.Any(p => p.PatientEmail == patient.PatientEmail))
            {
                AppUser userControl = context.Patients.FirstOrDefault(u => u.PatientEmail == patient.PatientEmail);
                if (userControl.Password == patient.Password)
                    return RedirectToAction("index","appointment");      
            }
            TempData["hataMesaji"] = "Lütfen Bilgileri Doğru Giriniz";
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AppUser user)
        {
            context.Patients.Add(user);
            context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
