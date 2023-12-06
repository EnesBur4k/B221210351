using B221210351.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B221210351.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
