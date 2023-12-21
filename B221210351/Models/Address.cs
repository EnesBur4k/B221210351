namespace B221210351.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public Neighbourhood Neighbourhood { get; set; }
        public Street Street { get; set; }
        public int ApartmentNo { get; set; }
    }
}
