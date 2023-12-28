using B221210351.EFContext;
using B221210351.Models;
using B221210351.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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

            CreateAppointmentVM model = new CreateAppointmentVM()
            {
                Appointments = appointmentList,
                Policlinics = context.Policlinics.ToList(),
                Doctors = context.Doctors.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AppointmentList(CreateAppointmentVM createAppointmentVM)
        {
            int tempUserId = Convert.ToInt32(userManager.GetUserId(HttpContext.User));//Kullanıcının UserId bilgisini alma
            List<Appointment> appointmentList = context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic)
                .Include(a => a.AppUser)
                .Where(a => a.AppUserId == tempUserId)
                .ToList();

            List<Appointment> creatingAppointmentList = context.Appointments
                .Where(a =>
                (a.AppointmentDate.Day == createAppointmentVM.AppointmentDate.Day) &&
                (a.DoctorId == createAppointmentVM.Doctor.DoctorId))
                .ToList();

            CreateAppointmentVM createAppointment = new CreateAppointmentVM
            {
                Appointments = appointmentList,
                creatingAppointments = creatingAppointmentList
            };
            //o tarihteki o doktordaki randevuları listele
            return View(createAppointment);
        }

        public IActionResult MakeAppointment(int appointmentId)
        {
            int tempUserId = Convert.ToInt32(userManager.GetUserId(HttpContext.User));//Kullanıcının UserId bilgisini alma

            Appointment appointment = context.Appointments.Find(appointmentId);

            if (appointment.AppointmentState.Equals("Boş"))
            {
                appointment.AppUser = context.Users.Find(tempUserId);
                appointment.AppointmentState = "Aktif";
                TempData["appointmentState"] = "Randevunuz başarıyla oluşturulmuştur.";

                context.SaveChanges();
            }
            else
            {
                TempData["appointmentState"] = "Bu randevu doludur.";
            }

            return RedirectToAction("index");
        }

        public IActionResult CancelAppointment(int appointmentId)
        {
            var appointment = context.Appointments.Include(a => a.AppUser).FirstOrDefault(a => a.AppointmentId == appointmentId);
            appointment.AppointmentState = "Boş";
            appointment.AppUser = null;

            context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
