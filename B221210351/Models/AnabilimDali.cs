namespace B221210351.Models
{
    public class AnabilimDali
    {
        AnabilimDali()
        {
            Poliklinikler = new HashSet<Poliklinik>();
        }
        public int AnabilimDaliId { get; set; }
        public string Ad { get; set; }

        public ICollection<Poliklinik> Poliklinikler { get; set; }
    }
}