namespace B221210351.Models
{
    public class Street
    {
        public Street()
        {
            Addresses = new HashSet<Address>();
        }
        public int StreetId { get; set; }
        public string StreetName { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
