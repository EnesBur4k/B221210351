using B221210351.Models;
using Microsoft.EntityFrameworkCore;

namespace B221210351.EFContext
{
    public class HastaneContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighbourhood> Neighbourhoods { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=HastaneDb;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Policlinic)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PoliclinicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.District)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.DistrictId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Neighbourhood)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.NeighbourhoodId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Street)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.StreetId);

            modelBuilder.Entity<Street>()
                .HasData(
                new Street
                {
                    StreetId = 1,
                    StreetName = "Yavuz Selim",

                },
                new Street
                {
                    StreetId = 2,
                    StreetName = "Teoman"
                },
                new Street
                {
                    StreetId = 3,
                    StreetName = "Toplum"
                }
                );

            modelBuilder.Entity<Neighbourhood>()
                .HasData(
                new Neighbourhood
                {
                    NeighbourhoodId = 1,
                    NeighbourhoodName = "Güzelyalı",

                },
                new Neighbourhood
                {
                    NeighbourhoodId = 2,
                    NeighbourhoodName = "Kaynarca"
                },
                new Neighbourhood
                {
                    NeighbourhoodId = 3,
                    NeighbourhoodName = "Çamçeşme"
                }
                );

            modelBuilder.Entity<District>()
                .HasData(
                new District
                {
                    DistrictId = 1,
                    DistrictName = "Pendik",

                },
                new District
                {
                    DistrictId = 2,
                    DistrictName = "Kartal"
                },
                new District
                {
                    DistrictId = 3,
                    DistrictName = "Maltepe"
                }
                );
            modelBuilder.Entity<City>()
                .HasData(
                new City
                {
                    CityId = 1,
                    CityName = "İstanbul",

                },
                new City
                {
                    CityId = 2,
                    CityName = "Kocaeli"
                },
                new City
                {
                    CityId = 3,
                    CityName = "Sakarya"
                }
                );
            
        }
    }
}
