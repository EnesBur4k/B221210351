namespace B221210351.Models
{
    public class Poliklinik
    {
        Poliklinik()
        {
            Doktorlar = new HashSet<Doktor>();
        }
        public int PoliklinikId { get; set; }
        public AnabilimDali AnabilimDali { get; set; }

        public ICollection<Doktor> Doktorlar { get; set; }
    }
}