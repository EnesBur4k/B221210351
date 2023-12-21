namespace B221210351.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighbourhoodId { get; set; }
        public int StreetId { get; set; }
        public int ApartmentNo { get; set; }

        public City City { get; set; }
        public District District { get; set; }
        public Neighbourhood Neighbourhood { get; set; }
        public Street Street { get; set; }
    }
}
