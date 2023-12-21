using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B221210351.Controllers
{
    public class HomeController : Controller
    {
        HastaneContext Context = new HastaneContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User User)
        {
            if(Context.Users.Any(u => u.UserName == User.UserName))
            {
                if(Context.Users.Any(u => u.Password == User.Password))
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
        public IActionResult Register(User User)
        {
            Context.Users.Add(User);
            Context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
