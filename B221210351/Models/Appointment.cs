namespace B221210351.Models
{
    public class Appointment
    {
        public int RandevuId { get; set; }
        public Policlinic Poliklinik { get; set; }
        public Doctor Doktor { get; set; }
        public Hasta Hasta { get; set; }
    }
}