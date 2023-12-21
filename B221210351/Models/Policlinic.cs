namespace B221210351.Models
{
    public class Policlinic
    {
        Policlinic()
        {
            Doctors = new HashSet<Doctor>();
            Appointments = new HashSet<Appointment>();
        }
        public int PoliclinicId { get; set; }
        public Department Department { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}