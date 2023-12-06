using B221210351.Models;
using Microsoft.EntityFrameworkCore;

namespace B221210351.EFContext
{
    public class HastaneContext : DbContext
    {
        DbSet<Admin> Adminler { get; set; }
        DbSet<Adres> Adresler { get; set; }
        DbSet<AnabilimDali> AnabilimDallari { get; set; }
        DbSet<Il> Sehirler { get; set; }
        DbSet<Ilce> Ilceler { get; set; }
        DbSet<Mahalle> Mahalleler { get; set; }
        DbSet<Doktor> Doktorlar { get; set; }
        DbSet<Hasta> Hastalar { get; set; }
        DbSet<Kisi> Kisiler { get; set; }
        DbSet<Poliklinik> Poliklinikler { get; set; }
        DbSet<Randevu> Randevular { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=HastaneDb;Trusted_Connection=True;");

        }
    }
}
