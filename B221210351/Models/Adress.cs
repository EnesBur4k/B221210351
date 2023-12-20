namespace B221210351.Models
{
    public class Adress
    {
        public int AdresId { get; set; }
        public City Il { get; set; }
        public District Ilce { get; set; }
        public Neighbourhood Mahalle { get; set; }
        public Street Cadde { get; set; }
        public int BinaNo { get; set; }
        public int DaireNo { get; set; }
    }
}
