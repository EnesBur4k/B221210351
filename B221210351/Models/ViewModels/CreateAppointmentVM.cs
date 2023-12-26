using System.ComponentModel.DataAnnotations;

namespace B221210351.Models.ViewModels
{
    public class CreateAppointmentVM
    {
        public AppUser User { get; set; }
        public Doctor Doctor { get; set; }
        public Appointment Appointment { get; set; }
        public Policlinic Policlinic { get; set; }
        public DateTime AppointmentDate { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Policlinic> Policlinics { get; set; }
    }
}
