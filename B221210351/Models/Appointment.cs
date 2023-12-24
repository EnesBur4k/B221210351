namespace B221210351.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int PoliclinicId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Policlinic Policlinic { get; set; }
        public Doctor Doctor { get; set; }
        public AppUser Patient { get; set; }
    }
}