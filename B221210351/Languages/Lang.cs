using Microsoft.AspNetCore.Mvc;

namespace B221210351.Languages
{
    public class Lang : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
