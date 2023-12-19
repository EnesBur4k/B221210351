using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace B221210351.Models
{
    public class Patient
    {
        Patient() 
        {
            Randevular = new HashSet<Randevu>();
        }
        public int HastaId { get; set; }
        public int KimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EMail { get; set; }
        public string Parola { get; set; }
        public DateTime DogumGunu { get; set; }
        public bool Cinsiyet { get; set; }
        public Adres Adres { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
    }
}
