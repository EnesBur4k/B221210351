using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B221210351.Areas.YonetimPaneli.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("yonetimPaneli")]
    public class AppointmentController : Controller
    {
        private readonly HastaneDbContext context;

        public AppointmentController(HastaneDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Appointment> appointments = context.Appointments
                .Include(a => a.AppUser)
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic).ToList();
            return View(appointments);
        }
    }
}
