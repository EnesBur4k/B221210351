using B221210351.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace B221210351.EFContext
{
    public class HastaneDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public HastaneDbContext(DbContextOptions<HastaneDbContext> options) : base(options)
        { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(u => u.AppUser)
                .WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Policlinic)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PoliclinicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppRole>()
                .HasData(
                new AppRole
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new AppRole
                {
                    Id = 2,
                    Name = "User",
                    NormalizedName = "USER"
                });

            //modelBuilder.Entity<AppUser>()
            //    .HasData(
            //    new AppUser
            //    {
            //        Id = 1,
            //        PatientName = "Enes Burak",
            //        PatientSurname = "Kaya",
            //        Email="221210351@sakarya.edu.tr",
            //    }); ;

            modelBuilder.Entity<Department>()
                .HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "İç Hastalıkları Anabilim Dalı"

                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Kardiyoloji Anabilim Dalı"

                },
               new Department
               {
                   DepartmentId = 3,
                   DepartmentName = "Göğüs Hastalıkları Anabilim Dalı"

               },
               new Department
               {
                   DepartmentId = 4,
                   DepartmentName = "Çocuk Sağlığı ve Hastalıkları Anabilim Dalı"

               },
               new Department
               {
                   DepartmentId = 5,
                   DepartmentName = "Ruh Sağlığı ve Hastalıkları Anabilim Dalı"

               },
               new Department
               {
                   DepartmentId = 6,
                   DepartmentName = "Nöroloji Anabilim Dalı"

               },
               new Department
               {
                   DepartmentId = 7,
                   DepartmentName = "Deri ve Zührevi Anabilim Dalı"

               },
               new Department
               {
                   DepartmentId = 8,
                   DepartmentName = "Genel Cerrahi Anabilim Dalı"

               });

            modelBuilder.Entity<Policlinic>()
                .HasData(
                new Policlinic
                {
                    PoliclinicId = 1,
                    DepartmentId = 1,
                    PoliclinicName = "Endokrinoloji ve Metabolizma Kliniği"

                },
                new Policlinic
                {
                    PoliclinicId = 2,
                    DepartmentId = 1,
                    PoliclinicName = "Gastroenteroloji Kliniği"

                },
               new Policlinic
               {
                   PoliclinicId = 3,
                   DepartmentId = 2,
                   PoliclinicName = "Kardiyoloji Kliniği"

               },
               new Policlinic
               {
                   PoliclinicId = 4,
                   DepartmentId = 3,
                   PoliclinicName = "Göğüs Hastalıkları Kliniği"

               },
               new Policlinic
               {
                   PoliclinicId = 5,
                   DepartmentId = 4,
                   PoliclinicName = "Çocuk Gastroenterolojisi Kliniği"

               },
               new Policlinic
               {
                   PoliclinicId = 6,
                   DepartmentId = 4,
                   PoliclinicName = "Çocuk Kardiyolojisi Kliniği"

               },
               new Policlinic
               {
                   PoliclinicId = 7,
                   DepartmentId = 5,
                   PoliclinicName = "Ruh Sağlığı ve Hastalıkları Kliniği"

               },
               new Policlinic
               {
                   PoliclinicId = 8,
                   DepartmentId = 6,
                   PoliclinicName = "Nöroloji Kliniği"

               },
               new Policlinic
               {
                   PoliclinicId = 9,
                   DepartmentId = 7,
                   PoliclinicName = "Deri ve Zührevi Hastalıklar Kliniği"

               },
               new Policlinic
               {
                   PoliclinicId = 10,
                   DepartmentId = 8,
                   PoliclinicName = "Genel Cerrahi Kliniği"

               });

            modelBuilder.Entity<Doctor>()
                .HasData(
                new Doctor
                {
                    DoctorId = 1,
                    DoctorName = "Asım",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 1
                },
                new Doctor
                {
                    DoctorId = 2,
                    DoctorName = "Basım",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 2
                },
                new Doctor
                {
                    DoctorId = 3,
                    DoctorName = "Casım",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 3
                },
                new Doctor
                {
                    DoctorId = 4,
                    DoctorName = "Dasım",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 4
                },
                new Doctor
                {
                    DoctorId = 5,
                    DoctorName = "Esim",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 5
                },
                new Doctor
                {
                    DoctorId = 6,
                    DoctorName = "Fesim",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 6
                },
                new Doctor
                {
                    DoctorId = 7,
                    DoctorName = "Kesim",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 7
                },
                new Doctor
                {
                    DoctorId = 8,
                    DoctorName = "Lesim",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 8
                },
                new Doctor
                {
                    DoctorId = 9,
                    DoctorName = "Tesim",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 9
                },
                new Doctor
                {
                    DoctorId = 10,
                    DoctorName = "Resim",
                    DoctorSurname = "Bar",
                    Gender = true,
                    PoliclinicId = 10
                });
        }
    }
}
