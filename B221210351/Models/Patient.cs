using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace B221210351.Models
{
    public class Patient
    {
        public Patient() 
        {
            Appointments = new HashSet<Appointment>();
        }
        public int PatientId { get; set; }
        public int PersonalId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Gender { get; set; }
        public Address Address { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
