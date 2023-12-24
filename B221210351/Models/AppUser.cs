using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace B221210351.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() 
        {
            Appointments = new HashSet<Appointment>();
        }
        public int AddressId { get; set; }
        public int PatientPersonalId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public bool PatientGender { get; set; }
        public DateTime PatientBirthDay { get; set; }
        public Address Address { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
