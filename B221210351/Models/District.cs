namespace B221210351.Models
{
    public class District
    {
        District()
        {
            Neighbourhoods = new HashSet<Neighbourhood>();
        }
        public int DistrictId { get; set; }
        public ICollection<Neighbourhood> Neighbourhoods { get; set; }
    }
}