namespace B221210351.Models
{
    public class Randevu
    {
        public int RandevuId { get; set; }
        public Poliklinik Poliklinik { get; set; }
        public Doktor Doktor { get; set; }
        public Hasta Hasta { get; set; }
    }
}