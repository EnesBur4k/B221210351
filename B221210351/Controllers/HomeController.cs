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
        public IActionResult Login(User user)
        {
            if(context.Users.Any(u => u.UserName == user.UserName))
            {
                User userControl = context.Users.FirstOrDefault(u => u.UserName == user.UserName);
                if (userControl.Password == user.Password)
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
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
