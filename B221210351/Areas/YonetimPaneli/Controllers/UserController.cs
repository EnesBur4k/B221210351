using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B221210351.Areas.YonetimPaneli.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("yonetimPaneli")]
    public class UserController : Controller
    {
        private readonly HastaneDbContext context;

        public UserController(HastaneDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<AppUser> patients = context.Users.ToList();
            return View(patients);
        }
    }
}
