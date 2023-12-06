namespace B221210351.Models
{
    public class Mahalle
    {
        Mahalle()
        {
            Caddeler = new HashSet<Cadde>();
        }
        public int MahalleId { get; set; }
        public ICollection<Cadde> Caddeler { get; set; }
    }
}