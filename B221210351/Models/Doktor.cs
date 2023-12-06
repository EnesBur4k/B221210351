namespace B221210351.Models
{
    public class Doktor : Kisi
    {
        public int CalismaSaati { get; set; }
        public int NobetGunleri { get; set; }
        public Poliklinik Poliklinik { get; set; }
    }
}
