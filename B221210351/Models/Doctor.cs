namespace B221210351.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthDay { get; set; }
        public bool Gender { get; set; }
        public int PersonalId { get; set; }
        public int WorkingHours { get; set; }
        public int WatchDays { get; set; }
        public Address Address { get; set; }
        public Policlinic Policlinic { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
