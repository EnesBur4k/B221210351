namespace B221210351.Models
{
    public class City
    {
        City()
        {
            Cities = new HashSet<District>();
        }
        public int CityId { get; set; }
        public ICollection<District> Cities { get; set; }
    }
}