namespace B221210351.Models
{
    public class Policlinic
    {
        Policlinic()
        {
            Doktorlar = new HashSet<Doctor>();
        }
        public int PoliklinikId { get; set; }
        public Department AnabilimDali { get; set; }

        public ICollection<Doctor> Doktorlar { get; set; }
    }
}