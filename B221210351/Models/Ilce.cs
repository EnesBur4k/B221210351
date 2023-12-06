namespace B221210351.Models
{
    public class Ilce
    {
        Ilce()
        {
            Mahalleler = new HashSet<Mahalle>();
        }
        public int IlceId { get; set; }
        public ICollection<Mahalle> Mahalleler { get; set; }
    }
}