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
    }
}
