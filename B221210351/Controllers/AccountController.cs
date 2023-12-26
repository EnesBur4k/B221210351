using Microsoft.AspNetCore.Mvc;

namespace B221210351.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return RedirectToAction("Login","Home");
        }
        public IActionResult AccessDenied(string? returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            TempData["HataMesaji"] = "Böyle bir kullanıcı bulunamadı.";
            return RedirectToAction("Login", "Home");
        }
    }
}
