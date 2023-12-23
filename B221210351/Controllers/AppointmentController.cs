using B221210351.EFContext;
using B221210351.Models;
using B221210351.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace B221210351.Controllers
{
    public class AppointmentController : Controller
    {
        HastaneContext context = new HastaneContext();
        public IActionResult Index()
        {
            AppointmentVM model = new AppointmentVM()
            {
                Policlinics = context.Policlinics.ToList(),
                Doctors = context.Doctors.ToList(),
            };
            return View(model);
        }
        public IActionResult CreateAppointment(AppointmentVM appointmentVM)
        {
            appointmentVM.Doctor = context.Doctors.Find(appointmentVM.Doctor.DoctorId);
            appointmentVM.Policlinic = context.Policlinics.Find(appointmentVM.Policlinic.PoliclinicId);

            Appointment appointment = new Appointment
            {
                Doctor = appointmentVM.Doctor,
                Policlinic = appointmentVM.Policlinic,
                AppointmentDate = appointmentVM.Appointment.AppointmentDate,
                Patient = context.Patients.Find(1)
            };

            context.Appointments.Add(appointment);
            context.SaveChanges();
            return View("index");
        }
    }
}
