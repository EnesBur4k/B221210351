namespace B221210351.Models
{
    public class Neighbourhood
    {
        public Neighbourhood()
        {
            Addresses = new HashSet<Address>();
        }
        public int NeighbourhoodId { get; set; }
        public string NeighbourhoodName { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}