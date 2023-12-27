using B221210351.EFContext;
using B221210351.Models;
using B221210351.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B221210351.Controllers
{
    [Authorize(Roles = "User")]
    public class AppointmentController : Controller
    {
        private readonly HastaneDbContext context;
        private readonly UserManager<AppUser> userManager;


        public AppointmentController(HastaneDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            int tempUserId = Convert.ToInt32(userManager.GetUserId(HttpContext.User));//Kullanıcının UserId bilgisini alma
            List<Appointment> appointmentList = context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic)
                .Include(a => a.AppUser)
                .Where(a => a.AppUserId == tempUserId)
                .ToList();

            List<Appointment> allAppointments = context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic)
                .ToList();

            CreateAppointmentVM model = new CreateAppointmentVM()
            {
                Appointments = appointmentList,
                Policlinics = context.Policlinics.ToList(),
                Doctors = context.Doctors.ToList(),
                AllAppointments = allAppointments
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult GetDoctorsByPoliclinicId(int policlinicId)
        {
            // Veritabanından ilgili policlinic'e bağlı doktorları al
            var doctors = context.Doctors.Where(d => d.PoliclinicId == policlinicId).ToList();// Burada veritabanından doktorları çekme işlemi yapılmalıdır.

            var doctorList = doctors.Select(d => new { d.DoctorId, DoctorName = d.DoctorName, DoctorSurname = d.DoctorSurname }).ToList();
            return Json(doctorList);
        }

        public IActionResult CreateAppointment(CreateAppointmentVM appointmentVM)
        {
            int tempUserId = Convert.ToInt32(userManager.GetUserId(HttpContext.User));
            Appointment appointment = new Appointment
            {
                Doctor = context.Doctors.Find(appointmentVM.Doctor.DoctorId),
                Policlinic = context.Policlinics.Find(appointmentVM.Policlinic.PoliclinicId),
                AppointmentDate = appointmentVM.Appointment.AppointmentDate,
                AppUser = context.Users.Find(tempUserId)
            };

            var isAppointmentEmpty = context.Appointments.Where(a =>
            (a.DoctorId == appointmentVM.Doctor.DoctorId &&
            a.AppointmentDate == appointmentVM.AppointmentDate)).Any();

            if (isAppointmentEmpty)
            {
                context.Appointments.Add(appointment);
                context.SaveChanges();
                TempData["randevu"] = "Randevu başarıyla alındı.";
            }
            else
            {
                TempData["randevu"] = "Almak istediğiniz randevu doludur.";
            }
            return RedirectToAction("index");
        }


        //public IActionResult CreateAppointment(CreateAppointmentVM appointmentVM)
        //{


        //    if (appointmentVM.Appointment.isActive)
        //    {
        //        context.Appointments.Add();
        //        context.SaveChanges();
        //        TempData["randevu"] = "Randevu başarıyla alındı.";
        //    }
        //    else
        //    {
        //        TempData["randevu"] = "Almak istediğiniz randevu doludur.";
        //    }
        //    return RedirectToAction("index");
        //}
    }
}
