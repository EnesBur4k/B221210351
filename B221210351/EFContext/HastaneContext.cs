using B221210351.Models;
using Microsoft.EntityFrameworkCore;

namespace B221210351.EFContext
{
    public class HastaneContext : DbContext
    {
        DbSet<Admin> Admins { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<Neighbourhood> Neighbourhoods { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        DbSet<Person> People { get; set; }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<Policlinic> Policlinics { get; set; }

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
                .HasOne(a =>a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a =>a.Policlinic)
                .WithMany(p  => p.Appointments)
                .HasForeignKey(a =>a.PoliclinicId)
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
