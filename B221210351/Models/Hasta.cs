namespace B221210351.Models
{
    public class Hasta : Kisi
    {
        Hasta() 
        {
            Randevular = new HashSet<Randevu>();
        }
        public ICollection<Randevu> Randevular { get; set; }
    }
}
