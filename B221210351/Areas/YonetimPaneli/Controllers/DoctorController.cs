using B221210351.Areas.YonetimPaneli.Models.ViewModels;
using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B221210351.Areas.YonetimPaneli.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("yonetimPaneli")]
    public class DoctorController : Controller
    {
        private readonly HastaneDbContext context;

        public DoctorController(HastaneDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            DoctorPageVM doctorPageVM = new()
            {
                Doctors = context.Doctors.Include(d => d.Policlinic.Department).ToList(),
                Policlinics = context.Policlinics.ToList()
            };
            return View(doctorPageVM);
        }

        [HttpPost]
        public async Task<IActionResult> addDoctorAsync(Doctor doctor)
        {
            var policlinic = context.Policlinics.Find(doctor.PoliclinicId);
            doctor.Policlinic = policlinic;
            await context.Doctors.AddAsync(doctor);
            context.SaveChanges();
            TempData["AddMessage"] = "Doktor başarıyla eklendi";
            return RedirectToAction("Index");
        }
    }
}
