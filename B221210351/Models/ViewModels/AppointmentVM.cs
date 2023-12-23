namespace B221210351.Models.ViewModels
{
    public class AppointmentVM
    {
        public Appointment Appointment { get; set; }
        public Policlinic Policlinic { get; set; }
        public Doctor Doctor { get; set; }
        public List<Policlinic> Policlinics { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
