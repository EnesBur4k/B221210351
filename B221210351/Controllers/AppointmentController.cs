using B221210351.EFContext;
using B221210351.Models;
using B221210351.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace B221210351.Controllers
{
    [Authorize(Roles = "User")]
    public class AppointmentController : Controller
    {
        private readonly HastaneDbContext context;

        public AppointmentController(HastaneDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            CreateAppointmentVM model = new CreateAppointmentVM()
            {
                Policlinics = context.Policlinics.ToList(),
                Doctors = context.Doctors.ToList(),
            };
            return View(model);
        }

        public IActionResult CreateAppointment(CreateAppointmentVM appointmentVM)
        {
            appointmentVM.Doctor = context.Doctors.Find(appointmentVM.Doctor.DoctorId);
            appointmentVM.Policlinic = context.Policlinics.Find(appointmentVM.Policlinic.PoliclinicId);

            Appointment appointment = new Appointment
            {
                Doctor = appointmentVM.Doctor,
                Policlinic = appointmentVM.Policlinic,
                AppointmentDate = appointmentVM.Appointment.AppointmentDate,
                AppUser = context.Users.Find(1)
            };

            context.Appointments.Add(appointment);
            context.SaveChanges();
            return View("index");
        }
    }
}
