namespace B221210351.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int AppUserId { get; set; }
        public int DoctorId { get; set; }
        public int PoliclinicId { get; set; }
        public AppUser AppUser { get; set; }
        public Doctor Doctor { get; set; }
        public Policlinic Policlinic { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}