namespace B221210351.Models
{
    public class District
    {
        District()
        {
            Mahalleler = new HashSet<Neighbourhood>();
        }
        public int IlceId { get; set; }
        public ICollection<Neighbourhood> Mahalleler { get; set; }
    }
}