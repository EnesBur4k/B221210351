namespace B221210351.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public bool Gender { get; set; }
        public int PoliclinicId { get; set; }
        //Nöbet günü ayarlanacak
        //public int WatchDays { get; set; }
        public Policlinic Policlinic { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
