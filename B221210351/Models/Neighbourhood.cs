namespace B221210351.Models
{
    public class Neighbourhood
    {
        Neighbourhood()
        {
            Streets = new HashSet<Street>();
        }
        public int NeighbourhoodId { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}