namespace B221210351.Models
{
    public class Doctor
    {
        public int DoktorId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int DogumGunu { get; set; }
        public bool Cinsiyet { get; set; }
        public int KimlikNo { get; set; }
        public int CalismaSaati { get; set; }
        public int NobetGunleri { get; set; }
        public Adress Adres { get; set; }
        public Policlinic Poliklinik { get; set; }
    }
}
