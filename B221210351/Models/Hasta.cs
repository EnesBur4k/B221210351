namespace B221210351.Models
{
    public class Hasta : Kisi
    {
        public int Id { get; set; }
        public ICollection<Randevu> Randevu { get; set; }
    }
}
