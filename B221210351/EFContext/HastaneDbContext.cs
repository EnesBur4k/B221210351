using B221210351.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace B221210351.EFContext
{
    public class HastaneDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public HastaneDbContext(DbContextOptions<HastaneDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighbourhood> Neighbourhoods { get; set; }
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

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.AppUser)
                .WithMany(p => p.Appointments)
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
                });

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
                });

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
                });

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
                });

            modelBuilder.Entity<Address>()
                .HasData(
                new Address
                {
                    AddressId = 1,
                    CityId = 1,
                    DistrictId = 1,
                    NeighbourhoodId = 1,
                    StreetId = 1,
                    ApartmentNo = 1
                },
                new Address
                {
                    AddressId = 2,
                    CityId = 1,
                    DistrictId = 2,
                    NeighbourhoodId = 2,
                    StreetId = 2,
                    ApartmentNo = 2
                },
                new Address
                {
                    AddressId = 3,
                    CityId = 1,
                    DistrictId = 3,
                    NeighbourhoodId = 3,
                    StreetId = 3,
                    ApartmentNo = 3
                });

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

            //modelBuilder.Entity<AppUser>()
            //    .HasData(
            //    new AppUser
            //    {
            //        Id = 1,
            //        PatientPersonalId = 100,
            //        PatientName = "Enes",
            //        PatientSurname = "Burak",
            //        PatientGender = true,
            //        Email = "enesburak@gmail.com",
            //        PatientBirthDay = DateTime.Now,
            //        AddressId = 1
            //    },
            //    new AppUser
            //    {
            //        Id = 2,
            //        PatientPersonalId = 101,
            //        PatientName = "Ogün",
            //        PatientSurname = "Şanlısoy",
            //        PatientGender = true,
            //        Email = "ogun@gmail.com",
            //        PatientBirthDay = DateTime.Now,
            //        AddressId = 2
            //    },
            //    new AppUser
            //    {
            //        Id = "3",
            //        PatientPersonalId = 102,
            //        PatientName = "Winston",
            //        PatientSurname = "Churchill",
            //        PatientGender = true,
            //        Email = "winston@gmail.com",
            //        PatientBirthDay = DateTime.Now,
            //        AddressId = 3
            //    },
            //    new AppUser
            //    {
            //        Id = "4",
            //        PatientPersonalId = 103,
            //        PatientName = "Emanuel",
            //        PatientSurname = "İcardi",
            //        PatientGender = true,
            //        Email = "goat@gmail.com",
            //        PatientBirthDay = DateTime.Now,
            //        AddressId = 2
            //    },
            //    new AppUser
            //    {
            //        Id = "5",
            //        PatientPersonalId = 104,
            //        PatientName = "Bülent",
            //        PatientSurname = "Ersoy",
            //        PatientGender = true,
            //        Email = "bulent@gmail.com",
            //        PatientBirthDay = DateTime.Now,
            //        AddressId = 1
            //    },
            //    new AppUser
            //    {
            //        Id = "6",
            //        PatientPersonalId = 105,
            //        PatientName = "Muazzez",
            //        PatientSurname = "Senar",
            //        PatientGender = true,
            //        Email = "senar@gmail.com",
            //        PatientBirthDay = DateTime.Now,
            //        AddressId = 3
            //    },
            //    new AppUser
            //    {
            //        Id = "7",
            //        PatientPersonalId = 106,
            //        PatientName = "Vincent",
            //        PatientSurname = "Van Gogh",
            //        PatientGender = true,
            //        Email = "gogh@gmail.com",
            //        PatientBirthDay = DateTime.Now,
            //        AddressId = 2
            //    },
            //    new AppUser
            //    {
            //        Id = "8",
            //        PatientPersonalId = 107,
            //        PatientName = "Werner",
            //        PatientSurname = "Heisenberg",
            //        PatientGender = true,
            //        Email = "heisenberg@gmail.com",
            //        PatientBirthDay = DateTime.Now,
            //        AddressId = 1
            //    });

        }
    }
}
