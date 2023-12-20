namespace B221210351.Models
{
    public class Neighbourhood
    {
        Neighbourhood()
        {
            Caddeler = new HashSet<Street>();
        }
        public int MahalleId { get; set; }
        public ICollection<Street> Caddeler { get; set; }
    }
}