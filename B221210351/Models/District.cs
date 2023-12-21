namespace B221210351.Models
{
    public class District
    {
        public District()
        {
            Addresses = new HashSet<Address>();
        }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}