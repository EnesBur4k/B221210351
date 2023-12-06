namespace B221210351.Models
{
    public class Doktor : Kisi
    {
        public Poliklinik Poliklinik { get; set; }
        public int CalismaSaati { get; set; }
        public int NobetGunleri { get; set; }
    }
}
