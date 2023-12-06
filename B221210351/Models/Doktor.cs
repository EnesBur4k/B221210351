namespace B221210351.Models
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int DogumGunu { get; set; }
        public bool Cinsiyet { get; set; }
        public int KimlikNo { get; set; }
        public int CalismaSaati { get; set; }
        public int NobetGunleri { get; set; }
        public Adres Adres { get; set; }
        public Poliklinik Poliklinik { get; set; }
    }
}
