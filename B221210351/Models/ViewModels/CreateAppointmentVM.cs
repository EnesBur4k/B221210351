using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace B221210351.Models.ViewModels
{
    public class CreateAppointmentVM
    {
        public Doctor Doctor { get; set; }
        public Policlinic Policlinic { get; set; }
        public DateTime AppointmentDate { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Policlinic> Policlinics { get; internal set; }
        public List<Appointment> creatingAppointments { get; set; }
        public List<Appointment> Appointments { get; internal set; }
    }
}
