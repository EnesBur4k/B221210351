namespace B221210351.Models
{
    public class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}