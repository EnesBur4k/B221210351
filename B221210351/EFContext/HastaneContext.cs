using B221210351.Models;
using Microsoft.EntityFrameworkCore;

namespace B221210351.EFContext
{
    public class HastaneContext : DbContext
    {
        DbSet<Admin> Adminler { get; set; }
        DbSet<Adress> Adresler { get; set; }
        DbSet<Department> AnabilimDallari { get; set; }
        DbSet<City> Sehirler { get; set; }
        DbSet<District> Ilceler { get; set; }
        DbSet<Neighbourhood> Mahalleler { get; set; }
        DbSet<Doctor> Doktorlar { get; set; }
        DbSet<Hasta> Hastalar { get; set; }
        //DbSet<Kisi> Kisiler { get; set; }
        DbSet<Policlinic> Poliklinikler { get; set; }
        DbSet<Appointment> Randevular { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=HastaneDb;Trusted_Connection=True;");

        }
    }
}
